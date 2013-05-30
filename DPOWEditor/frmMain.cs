using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Mogre;

namespace DPOWEditor
{
    public partial class frmMain : Form
    {
        DPOW.Reader.DPOWObject dpow;
        Root mRoot;
        SceneManager mgr;
        RenderWindow mWindow;
        string SelectedItem = "", openedFile;
        int openedSubFile;
        bool autoplay = false;
        int preX = -1, preY = -1;

        public frmMain()
        {
            InitializeComponent();
        }

        private void init3D()
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));

            // Create root object
            mRoot = new Root();

            // Define Resources
            ConfigFile cf = new ConfigFile();
            cf.Load("resources.cfg", "\t:=", true);
            ConfigFile.SectionIterator seci = cf.GetSectionIterator();
            String secName, typeName, archName;

            while (seci.MoveNext())
            {
                secName = seci.CurrentKey;
                ConfigFile.SettingsMultiMap settings = seci.Current;
                foreach (KeyValuePair<string, string> pair in settings)
                {
                    typeName = pair.Key;
                    archName = pair.Value;
                    ResourceGroupManager.Singleton.AddResourceLocation(archName, typeName, secName);
                }
            }

            // Setup RenderSystem
            RenderSystem rs = mRoot.GetRenderSystemByName("Direct3D9 Rendering Subsystem");
            mRoot.RenderSystem = rs;
            rs.SetConfigOption("Full Screen", "No");
            rs.SetConfigOption("Video Mode", "800 x 600 @ 32-bit colour");

            // Create Render Window
            mRoot.Initialise(false, "Main Ogre Window");
            NameValuePairList misc = new NameValuePairList();
            misc["externalWindowHandle"] = picRender.Handle.ToString();
            mWindow = mRoot.CreateRenderWindow("Main RenderWindow", 800, 600, false, misc);

            // Init resources
            TextureManager.Singleton.DefaultNumMipmaps = 5;
            ResourceGroupManager.Singleton.InitialiseAllResourceGroups();

            // Create a Simple Scene
            mgr = mRoot.CreateSceneManager(SceneType.ST_GENERIC, "MainMgr");
            Camera cam = mgr.CreateCamera("Camera");
            //cam.PolygonMode = PolygonMode.PM_WIREFRAME;
            cam.AutoAspectRatio = true;
            mWindow.AddViewport(cam);

            cam.Position = new Vector3(0, 0, 200);
            cam.LookAt(new Vector3(0,0,0));
            cam.ProjectionType = ProjectionType.PT_ORTHOGRAPHIC;
            //cam.OrthoWindowHeight = 400;
            cam.OrthoWindowWidth = 650;

            ManualObject manual = mgr.CreateManualObject("canvas");
            manual.Begin("BaseWhiteNoLighting", RenderOperation.OperationTypes.OT_LINE_STRIP);

            manual.Position(-300.0f, -200.0f, 0.0f);  // start position
            manual.Position(300.0f, -200.0f, 0.0f);  // draw first line
            manual.Position(300.0f, 200.0f, 0.0f);
            manual.Position(-300.0f, 200.0f, 0.0f);
            manual.Position(-300.0f, -200.0f, 0.0f);  // draw fourth line

            manual.End();
            mgr.RootSceneNode.CreateChildSceneNode().AttachObject(manual);

            mWindow.GetViewport(0).BackgroundColour = new ColourValue(0.5f, 0.5f, 0.5f);
        }

        private string loadstring(Stream thestream)
        {
            string result;
            byte[] newchar = new byte[1];
            newchar[0] = (byte)thestream.ReadByte();
            result = "";
            while (newchar[0] != 0)
            {
                result += System.Text.Encoding.UTF8.GetString(newchar);
                newchar[0] = (byte)thestream.ReadByte();
            }
            return result;
        }

        private void refreshLists()
        {
            treObjects.Nodes.Clear();
            for (int i = 0; i < dpow.Animations.Length; i++)
            {
                if (dpow.Animations[i].ParentId == -1)
                {
                    addnode(dpow.Animations[i], treObjects.Nodes);
                }
            }

            lstTextures.Items.Clear();
            for (int i = 0; i < dpow.Textures.Length; i++)
            {
                lstTextures.Items.Add(dpow.Textures[i]);
                ((MaterialPtr)MaterialManager.Singleton.GetByName("BaseNoCull", ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME)).Clone(dpow.Textures[i]);
            }

            lstVariables.Items.Clear();
            lstVariables.ItemChecked -= new ItemCheckedEventHandler(lstVariables_ItemChecked);
            for (int i = 0; i < dpow.Variables.Length; i++)
                lstVariables.Items.Add(dpow.Variables[i].Name).Checked = dpow.Variables[i].Enabled;
            lstVariables.ItemChecked += new ItemCheckedEventHandler(lstVariables_ItemChecked);


            treObjects.SelectedNode = treObjects.Nodes[0];

            mRoot.RenderOneFrame();
        }

        private void addnode(DPOW.Reader.Animation newanim, TreeNodeCollection parent)
        {
            TreeNode newnode = parent.Add(newanim.Name);
            for (int i = 0; i < newanim.Childs.Length; i++)
                addnode(newanim.getChild(i), newnode.Nodes);
        }

        private void openBINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.Cancel)
                return;

            openfile(dlgOpenFile.FileName);
        }

        private void openfile(string filename)
        {
            openedFile = filename;
            PESTool.Tools pestools = new PESTool.Tools();
            MemoryStream memstream = new MemoryStream();
            pestools.decompresstoMemory(filename, memstream);
            MemoryStream[] subfiles = pestools.splitmultifile(memstream, false);

            List<string> availabledpows = new List<string>();
            for (int i = 0; i < subfiles.Length; i++)
            {
                byte[] buffer = new byte[4];
                subfiles[i].Read(buffer, 0, 4);
                if (System.Text.Encoding.ASCII.GetString(buffer) == "DPOW")
                    availabledpows.Add(pestools.fnames[i]);
                subfiles[i].Seek(0, SeekOrigin.Begin);
            }

            int k = 0;
            string openingfile = "";
            if (availabledpows.Count == 0)
            {
                MessageBox.Show("No DPOWs on this file");
                return;
            }
            else if (availabledpows.Count > 1)
            {
                frmSelectSubfile frmPickFile = new frmSelectSubfile();
                frmPickFile.subfiles = availabledpows.ToArray();
                frmPickFile.ShowDialog();
                openingfile = frmPickFile.cmbSubfile.Text;
            }
            else
                openingfile = availabledpows[0];

            for (int i = 0; i < subfiles.Length; i++)
            {
                if (pestools.fnames[i] == openingfile)
                    k = i;
            }
            dpow = new DPOW.Reader.DPOWObject(subfiles[k]);
            openedSubFile = k;

            init3D();

            refreshLists();

            string dir = Path.GetDirectoryName(filename);
            for (int i = 0; i < dpow.Textures.Length; i++)
                if (File.Exists(dir + "\\" + dpow.Textures[i] + ".png"))
                {
                    createMaterial(dpow.Textures[i], System.Drawing.Image.FromFile(dir + "\\" + dpow.Textures[i] + ".png"));

                    imlTextures.Images.Add(dpow.Textures[i], System.Drawing.Image.FromFile(dir + "\\" + dpow.Textures[i] + ".png"));
                    lstTextures.Items[i].ImageKey = dpow.Textures[i];
                }

            lstTextures.Refresh();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Length > 1)
                openfile(Environment.GetCommandLineArgs()[1]);
        }

        private void treObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            trcFrameBar.Value = 0;

            lstVariables.Items.Clear();
            DPOW.Reader.Animation obj = dpow.getAnimation(e.Node.Text);
            lstVariables.ItemChecked -= new ItemCheckedEventHandler(lstVariables_ItemChecked);
            addVariablesOnList(obj);
            lstVariables.ItemChecked += new ItemCheckedEventHandler(lstVariables_ItemChecked);

            trcFrameBar.Maximum = obj.MaxTime;

            prpProperties.SelectedObject = obj;
            tmlMainTimeLine.SelectedAnimation = obj;

            if (autoplay)
                tmrPlay.Enabled = true;
            else
                drawFrame();
        }

        private void addVariablesOnList(DPOW.Reader.Animation obj)
        {
            for (int i = 0; i < obj.Events.Length; i++)
            {
                if(!lstVariables.Items.ContainsKey(obj.getVariable(i).Name))
                    lstVariables.Items.Add(obj.getVariable(i).Name, obj.getVariable(i).Name, 0).Checked = obj.getVariable(i).Enabled;
            }

            for (int j = 0; j < obj.Childs.Length; j++)
                addVariablesOnList(obj.getChild(j));
        }

        private void loadFrame(DPOW.Reader.Animation obj, int time, SceneNode parent)
        {
            SceneNode node;

            if (obj.getFrameOnTime(time) == null)
                return;
            int objid = obj.getFrameOnTime(time).ElementId;
            if (mgr.HasSceneNode("Element" + objid.ToString() + "_node"))
            {
                node = mgr.GetSceneNode("Element" + objid.ToString() + "_node");
                if(node.Parent != null)
                    node.Parent.RemoveChild(node);
                parent.AddChild(node);
            }
            else
            {
                node = buildElement(dpow.Elements[objid], "Element" + objid.ToString());
                parent.AddChild(node);
            }

            for (int i = 0; i < obj.Childs.Length; i++)
            {
                if (obj.Childs[i].ChildIcon < 0)
                    loadFrame(dpow.Animations[obj.Childs[i].ChildId], time, node);
                else
                    loadFrame(dpow.Animations[obj.Childs[i].ChildId], time, mgr.GetSceneNode("Element" + objid.ToString() + "_flag" + obj.Childs[i].ChildIcon.ToString() + "_node"));
            }
        }

        private SceneNode buildElement(DPOW.Reader.Element elem, string name)
        {
            if (mgr.HasSceneNode(name + "_node"))
                return mgr.GetSceneNode(name + "_node");

            SceneNode node = mgr.CreateSceneNode(name + "_node");
            node.SetPosition(elem.Position.X * 200, -elem.Position.Y * 200, -elem.Position.Z * 10);

            for (int i = 0; i < elem.Images.Length; i++)
            {
                string imgname = name + "_text" + i.ToString();

                SceneNode textnode = node.CreateChildSceneNode(name + "_text" + i.ToString() + "_node", new Vector3(elem.Images[i].Position.X * 200, -elem.Images[i].Position.Y * 200, -elem.Images[i].Position.Z * 10));
                ManualObject manual = mgr.CreateManualObject(name + "_text" + i.ToString());
                string matname;
                matname = dpow.Textures[elem.Images[i].TextureId];
                // Build new material, if it's selected
                if (imgname == SelectedItem)
                {
                    matname = "Selected";
                }
                /*else
                {
                    MaterialPtr newmat = ((MaterialPtr)MaterialManager.Singleton.GetByName(matname, ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME)).Clone(imgname + "_mat");
                    matname = imgname + "_mat";
                }*/
                manual.Begin(matname, RenderOperation.OperationTypes.OT_TRIANGLE_STRIP);

                for (int j = 0; j < elem.Images[i].Points.Length; j++)
                {
                    manual.Position(elem.Images[i].Points[j].X * 200, -elem.Images[i].Points[j].Y * 200, -elem.Images[i].Points[j].Z * 10);
                    manual.TextureCoord(elem.Images[i].Points[j].U, elem.Images[i].Points[j].V);
                    if(elem.Images[i].isGradient)
                        manual.Colour((float)elem.Images[i].Points[j].Color.R/255, (float)elem.Images[i].Points[j].Color.G / 255, (float)elem.Images[i].Points[j].Color.B / 255, (float)elem.Images[i].Points[j].Color.A / 255);
                }

                manual.End();

                textnode.AttachObject(manual);
            }

            for (int i = 0; i < elem.Texts.Length; i++)
            {
                SceneNode strnode = node.CreateChildSceneNode(name + "_str" + i.ToString() + "_node", new Vector3(elem.Texts[i].Position.X * 200, -elem.Texts[i].Position.Y * 200, -elem.Texts[i].Position.Z * 10));

                ManualObject manual = mgr.CreateManualObject(name + "_str" + i.ToString());
                manual.Begin("String", RenderOperation.OperationTypes.OT_TRIANGLE_STRIP);

                float left = 0;
                float right = elem.Texts[i].Size.X * 200;
                float bottom = -elem.Texts[i].Size.Y * 200.0f;
                float top = 0;
                manual.Position(left, bottom, 0);
                manual.Position(right, bottom, 0);
                manual.Position(left, top, 0);
                manual.Position(right, top, 0);

                manual.End();

                strnode.AttachObject(manual);
            }
            
            for (int i = 0; i < elem.Icons.Length; i++)
            {
                SceneNode flagnode = node.CreateChildSceneNode(name + "_flag" + i.ToString() + "_node", new Vector3(elem.Icons[i].Position.X * 200, -elem.Icons[i].Position.Y * 200, -elem.Icons[i].Position.Z * 10));

                ManualObject manual = mgr.CreateManualObject(name + "_flag" + i.ToString());
                manual.Begin("Flag", RenderOperation.OperationTypes.OT_TRIANGLE_STRIP);

                float left = 0;
                float right = elem.Icons[i].Size.X * 200;
                float bottom = -elem.Icons[i].Size.Y * 200.0f;
                float top = 0;
                if (elem.Icons[i].WTF == 0)
                {
                    left = -elem.Icons[i].Size.X / 2 * 200;
                    right = elem.Icons[i].Size.X / 2 * 200;
                    bottom = -elem.Icons[i].Size.Y / 2 * 200.0f;
                    top = elem.Icons[i].Size.Y / 2 * 200.0f;
                }
                manual.Position(left, bottom, 0);
                manual.Position(right, bottom, 0);
                manual.Position(left, top, 0);
                manual.Position(right, top, 0);

                manual.End();

                flagnode.AttachObject(manual);
            }
            
            return node;
        }

        private void picRender_Paint(object sender, PaintEventArgs e)
        {
            if (mRoot != null)
                mRoot.RenderOneFrame();
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void picRender_Layout(object sender, LayoutEventArgs e)
        {
            
        }

        private void picRender_Resize(object sender, EventArgs e)
        {
            picRender.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmrPlay.Enabled = true;
        }

        private void tmrPlay_Tick(object sender, EventArgs e)
        {
            if (trcFrameBar.Value < trcFrameBar.Maximum)
                trcFrameBar.Value++;
            else
                tmrPlay.Enabled = false;
        }

        private void trcFrameBar_ValueChanged(object sender, EventArgs e)
        {
            tmlMainTimeLine.CurrentFrame = trcFrameBar.Value;

            drawFrame();
        }

        private void drawFrame()
        {
            DPOW.Reader.Animation obj = dpow.getAnimation(treObjects.SelectedNode.Text);

            clearScene(mgr.RootSceneNode);
            loadFrame(obj, trcFrameBar.Value, mgr.RootSceneNode);

            mRoot.RenderOneFrame();
        }

        private void clearScene(SceneNode node)
        {
            ushort j = 0;

            // Clear Scene
            while (node.NumChildren() > j)
                if (node.GetChild(j).Name.StartsWith("Element"))
                {
                    SceneNode cnode = (SceneNode)node.GetChild(j);
                    clearScene(cnode);
                    while (cnode.NumAttachedObjects() > 0)
                    {
                        string entname = cnode.GetAttachedObject(0).Name;
                        cnode.DetachObject(entname);
                        mgr.DestroyManualObject(entname);
                    }
                    node.RemoveChild(cnode.Name);
                    mgr.DestroySceneNode(cnode.Name);
                }
                else
                    j++;
        }

        private void picRender_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            SelectedItem = "";

            RaySceneQuery mRaySceneQuery = null;

            // Save mouse position
            float mouseX = (float)e.X / picRender.Width; float mouseY = (float)e.Y / picRender.Height;

            // Setup the ray scene query
            Ray mouseRay = mgr.GetCamera("Camera").GetCameraToViewportRay(mouseX, mouseY);
            mRaySceneQuery = mgr.CreateRayQuery(mouseRay);

            // Execute query
            RaySceneQueryResult result = mRaySceneQuery.Execute();
            RaySceneQueryResultEntry oneobj;

            ctxPickObject.Items.Clear();

            // Get results, create a node/entity on the position
            for (Int16 i = 0; i < result.Count; i++)
            {
                oneobj = result[i];

                if (oneobj.movable != null && oneobj.movable.Name != "canvas")
                {
                    ctxPickObject.Items.Add(oneobj.movable.Name).Click += new EventHandler(ItemPicked);
                }
            } // 

            ctxPickObject.Show(picRender, e.X, e.Y);

            drawFrame();
        }

        private void timeLine1_FrameChanged()
        {
            if(tmlMainTimeLine.CurrentFrame <= trcFrameBar.Maximum)
                trcFrameBar.Value = tmlMainTimeLine.CurrentFrame;
        }

        private void ItemPicked(object sender, EventArgs e)
        {
            string itemname = ((ToolStripItem)sender).Text;
            SelectedItem = itemname;

            if (itemname.Contains("flag"))
            {
                int k = int.Parse(itemname.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(itemname.Split('_')[1].Replace("flag", ""));
                prpProperties.SelectedObject = dpow.Elements[k].Icons[l];
            }
            else if (itemname.Contains("str"))
            {
                int k = int.Parse(itemname.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(itemname.Split('_')[1].Replace("str", ""));
                prpProperties.SelectedObject = dpow.Elements[k].Texts[l];
            }
            else if (itemname.Contains("text"))
            {
                int k = int.Parse(itemname.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(itemname.Split('_')[1].Replace("text", ""));
                prpProperties.SelectedObject = dpow.Elements[k].Images[l];
            }

            drawFrame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tmrPlay.Enabled = false;
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgOpenImage.ShowDialog() == DialogResult.Cancel)
                return;

            imlTextures.Images.Add(lstTextures.SelectedItems[0].Text, System.Drawing.Image.FromFile(dlgOpenImage.FileName));
            lstTextures.SelectedItems[0].ImageKey = lstTextures.SelectedItems[0].Text;

            createMaterial(lstTextures.SelectedItems[0].Text, System.Drawing.Image.FromFile(dlgOpenImage.FileName));

            lstTextures.Refresh();
        }

        private void createMaterial(string name, System.Drawing.Image img)
        {
            TexturePtr tex = TextureManager.Singleton.Create(name, ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME, true);
            tex.LoadImage(SystemtoMogreImage(img));

            MaterialPtr mat = MaterialManager.Singleton.GetByName(name, ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME);
            if (mat == null)
            {
                mat = MaterialManager.Singleton.Create(name, ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME);
            }
            mat.CreateTechnique().CreatePass();
            mat.GetTechnique(0).GetPass(0).CreateTextureUnitState(name);
            mat.GetTechnique(0).GetPass(0).LightingEnabled = false;
            mat.GetTechnique(0).GetPass(0).CullingMode = CullingMode.CULL_NONE;
            mat.GetTechnique(0).GetPass(0).PolygonMode = PolygonMode.PM_SOLID;
            mat.GetTechnique(0).GetPass(0).SetSceneBlending(SceneBlendType.SBT_TRANSPARENT_ALPHA);
        }

        private Mogre.Image SystemtoMogreImage(System.Drawing.Image image)
        {
            Stream oStream = new MemoryStream();
            image.Save(oStream, System.Drawing.Imaging.ImageFormat.Png);

            /* Back to the start of the stream */
            oStream.Position = 0;

            /* read all the stream in a buffer */
            BinaryReader oBinaryReader = new BinaryReader(oStream);
            byte[] pBuffer = oBinaryReader.ReadBytes((int)oBinaryReader.BaseStream.Length);
            oStream.Close(); /*No more needed */

            Mogre.Image oMogreImage = new Mogre.Image();

            unsafe
            {
                System.Runtime.InteropServices.GCHandle handle = System.Runtime.InteropServices.GCHandle.Alloc(pBuffer, System.Runtime.InteropServices.GCHandleType.Pinned);
                byte* pUnsafeByte = (byte*)handle.AddrOfPinnedObject();
                void* pUnsafeBuffer = (void*)handle.AddrOfPinnedObject();

                MemoryDataStream oMemoryStream = new MemoryDataStream(pUnsafeBuffer, (uint)pBuffer.Length);
                DataStreamPtr oPtrDataStream = new DataStreamPtr(oMemoryStream);
                oMogreImage = oMogreImage.Load(oPtrDataStream, "png");
                handle.Free();
            }

            return oMogreImage;
        }

        private void ctxTextureMenu_Opening(object sender, CancelEventArgs e)
        {
            if (lstTextures.SelectedIndices.Count == 0)
                e.Cancel = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrPlay.Enabled = false;

            Application.DoEvents();
        }

        private void mnuShowIcons_Click(object sender, EventArgs e)
        {
            MaterialPtr mat = MaterialManager.Singleton.GetByName("Flag", ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME);

            if (mnuShowIcons.Checked)
                mat.GetTechnique(0).GetPass(0).GetTextureUnitState(0).SetAlphaOperation(LayerBlendOperationEx.LBX_SOURCE1, LayerBlendSource.LBS_MANUAL, LayerBlendSource.LBS_CURRENT, 0.4f);
            else
                mat.GetTechnique(0).GetPass(0).GetTextureUnitState(0).SetAlphaOperation(LayerBlendOperationEx.LBX_SOURCE1, LayerBlendSource.LBS_MANUAL, LayerBlendSource.LBS_CURRENT, 0.0f);

            mRoot.RenderOneFrame();
        }

        private void mnuSideView_Click(object sender, EventArgs e)
        {
            Camera cam = mgr.GetCamera("Camera");

            if (mnuSideView.Checked)
                mgr.GetCamera("Camera").SetPosition(200, 0, 0);
            else
                mgr.GetCamera("Camera").SetPosition(0, 0, 200);

            cam.AutoAspectRatio = true;
            cam.LookAt(new Vector3(0, 0, 0));
            cam.ProjectionType = ProjectionType.PT_ORTHOGRAPHIC;
            //cam.OrthoWindowHeight = 400;

            mRoot.RenderOneFrame();
        }

        private void lstVariables_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            dpow.getVariable(e.Item.Text).Enabled = e.Item.Checked;

            clearScene(mgr.RootSceneNode);
            loadFrame(dpow.getAnimation(treObjects.SelectedNode.Text), trcFrameBar.Value, mgr.RootSceneNode);
            tmlMainTimeLine.SelectedAnimation = dpow.getAnimation(treObjects.SelectedNode.Text);

            mRoot.RenderOneFrame();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgSaveFile.ShowDialog() == DialogResult.Cancel)
                return;

            PESTool.Tools pestools = new PESTool.Tools();
            MemoryStream stream = new MemoryStream();
            pestools.decompresstoMemory(openedFile, stream);
            MemoryStream[] subfiles = pestools.splitmultifile(stream, false);
            subfiles[openedSubFile] = new MemoryStream();

            dpow.SaveToFile(subfiles[openedSubFile]);

            stream = pestools.mergemultifile(subfiles, false);
            pestools.compressFile(stream, dlgSaveFile.FileName, false);
        }

        private void prpProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            tmlMainTimeLine.Refresh();

            drawFrame();
        }

        private void timeLine1_ElementSelected(int SelectedElementId)
        {
            prpProperties.SelectedObject = dpow.Elements[SelectedElementId];
        }

        private void ctxAnimationMenu_Opening(object sender, CancelEventArgs e)
        {
            if (treObjects.SelectedNode == null)
                e.Cancel = true;
        }

        private void treObjects_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (treObjects.GetNodeAt(e.X, e.Y) != null)
                {
                    treObjects.SelectedNode = treObjects.GetNodeAt(e.X, e.Y);
                    ctxAnimationMenu.Show(treObjects.PointToScreen(new Point(e.X, e.Y)));
                }
            }
        }

        private void autoplayOnClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoplayOnClickToolStripMenuItem.Checked = !autoplayOnClickToolStripMenuItem.Checked;
            autoplay = autoplayOnClickToolStripMenuItem.Checked;
        }

        private void mnuAnimationAddChild_Click(object sender, EventArgs e)
        {
            frmAddAnimationChild AddAnimationChildForm = new frmAddAnimationChild();
            AddAnimationChildForm.currentAnimations = dpow.Animations;
            int i = 0;
            while (dpow.getAnimation(treObjects.SelectedNode.Text).getFrameOnTime(i) == null)
                i++;
            AddAnimationChildForm.icons = dpow.getAnimation(treObjects.SelectedNode.Text).getFrameOnTime(i).Element.Icons.Length;
            if (AddAnimationChildForm.ShowDialog() == DialogResult.Cancel)
                return;

            dpow.getAnimation(treObjects.SelectedNode.Text).addChild(AddAnimationChildForm.selectedAnimation, AddAnimationChildForm.icon);
            treObjects.SelectedNode.Nodes.Add(AddAnimationChildForm.selectedAnimation.Name);
            treObjects.Refresh();
        }

        private void timeLine1_KeyFrameAdded(DPOW.Reader.Animation animation, int Time)
        {
            animation.AddKeyFrame((short)Time);

            trcFrameBar.Maximum = dpow.getAnimation(treObjects.SelectedNode.Text).MaxTime;
        }

        private void eventsOnTimelineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eventsOnTimelineToolStripMenuItem.Checked = !eventsOnTimelineToolStripMenuItem.Checked;

            tmlMainTimeLine.HandleAnimationEvents = eventsOnTimelineToolStripMenuItem.Checked;
        }

        private void timeLine1_KeyFrameRemoved(DPOW.Reader.Animation animation, int Time)
        {
            DPOW.Reader.Element elem = animation.getFrameOnTime(Time, false).Element;
            animation.RemoveKeyFrame((short)Time);
            if(!animation.HasElement(elem))
                dpow.RemoveElement(elem);

            trcFrameBar.Maximum = dpow.getAnimation(treObjects.SelectedNode.Text).MaxTime;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dpow.getAnimation(treObjects.SelectedNode.Parent.Text).removeChild(dpow.getAnimation(treObjects.SelectedNode.Text));
            treObjects.SelectedNode.Remove();
            treObjects.Refresh();

            //refreshLists();
        }

        private void addImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTextDialog TextDialog = new frmTextDialog("New Animation", "Name");
            if (TextDialog.ShowDialog() == DialogResult.OK)
            {
                dpow.AddTexture(TextDialog.txtMainTextBox.Text);
                lstTextures.Items.Add(TextDialog.txtMainTextBox.Text);
            }
        }

        private void picRender_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                picRender.Cursor = Cursors.SizeAll;
                if (preX != -1 && mgr.HasSceneNode(SelectedItem + "_node"))
                {
                    Vector3 vec = new Vector3(2 * (float)(e.X - preX) / (float)picRender.Height, - 2 * (float)(e.Y - preY) / (float)picRender.Height, 0);
                    if (SelectedItem.Contains("flag"))
                    {
                        int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                        int l = int.Parse(SelectedItem.Split('_')[1].Replace("flag", ""));
                        dpow.Elements[k].Icons[l].Position.X += vec.x;
                        dpow.Elements[k].Icons[l].Position.Y -= vec.y;
                    }
                    else if (SelectedItem.Contains("str"))
                    {
                        int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                        int l = int.Parse(SelectedItem.Split('_')[1].Replace("str", ""));
                        dpow.Elements[k].Texts[l].Position.X += vec.x;
                        dpow.Elements[k].Texts[l].Position.Y -= vec.y;
                    }
                    else if (SelectedItem.Contains("text"))
                    {
                        int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                        int l = int.Parse(SelectedItem.Split('_')[1].Replace("text", ""));
                        dpow.Elements[k].Images[l].Position.X += vec.x;
                        dpow.Elements[k].Images[l].Position.Y -= vec.y;
                    }
                    vec.x *= 200;
                    vec.y *= 200;
                    mgr.GetSceneNode(SelectedItem+"_node").Position += vec;

                    mRoot.RenderOneFrame();
                }

                preX = e.X;
                preY = e.Y;
            }
            else
            {
                preX = -1;
                preY = -1;
                picRender.Cursor = Cursors.Default;
            }

            if (mgr == null)
                return;

            // Save mouse position
            float mouseX = (float)e.X / picRender.Width; float mouseY = (float)e.Y / picRender.Height;
            // Setup the ray scene query
            Ray mouseRay = mgr.GetCamera("Camera").GetCameraToViewportRay(mouseX, mouseY);
            lblPointer.Text = (mouseRay.GetPoint(0).x / 200).ToString() + ", " + (-mouseRay.GetPoint(0).y / 200).ToString();
        }

        private void duplicateSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem == string.Empty)
            {
                MessageBox.Show("Nothing to duplicate!");
                return;
            }

            DPOW.Reader.Animation obj = dpow.getAnimation(treObjects.SelectedNode.Text);
            if (SelectedItem.Contains("flag"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("flag", ""));
                obj.getFrameOnTime(trcFrameBar.Value).Element.addIcon(DPOW.Reader.Animation.DeepClone<DPOW.Reader.Icon>(dpow.Elements[k].Icons[l]));
            }
            else if (SelectedItem.Contains("str"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("str", ""));
                obj.getFrameOnTime(trcFrameBar.Value).Element.addText(DPOW.Reader.Animation.DeepClone<DPOW.Reader.Text>(dpow.Elements[k].Texts[l]));
            }
            else if (SelectedItem.Contains("text"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("text", ""));
                obj.getFrameOnTime(trcFrameBar.Value).Element.addImage(DPOW.Reader.Animation.DeepClone<DPOW.Reader.Image>(dpow.Elements[k].Images[l]));
            }

        }

        private string Serialize(object objectToSerialize)
        {
            string serialString = null;
            using (System.IO.MemoryStream ms1 = new System.IO.MemoryStream())
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                b.Serialize(ms1, objectToSerialize);
                byte[] arrayByte = ms1.ToArray();
                serialString = Convert.ToBase64String(arrayByte);
            }
            return serialString;
        }
        private object DeSerialize(string serializationString)
        {
            object deserialObject = null;
            byte[] arrayByte = Convert.FromBase64String(serializationString);
            using (System.IO.MemoryStream ms1 = new System.IO.MemoryStream(arrayByte))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                deserialObject = b.Deserialize(ms1);
            }
            return deserialObject;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem.Contains("flag"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("flag", ""));
                Clipboard.SetData("DPOWIcon", Serialize(dpow.Elements[k].Icons[l]));
            }
            else if (SelectedItem.Contains("str"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("str", ""));
                Clipboard.SetData("DPOWText", Serialize(dpow.Elements[k].Texts[l]));
            }
            else if (SelectedItem.Contains("text"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("text", ""));
                Clipboard.SetData("DPOWImage", Serialize(dpow.Elements[k].Images[l]));
            }
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (SelectedItem == "" || SelectedItem == null)
            {
                duplicateSelectedToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
            }
            else
            {
                duplicateSelectedToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
            }

            if (Clipboard.ContainsData("DPOWImage") || Clipboard.ContainsData("DPOWText") || Clipboard.ContainsData("DPOWIcon"))
                pastToolStripMenuItem.Enabled = true;
            else
                pastToolStripMenuItem.Enabled = false;
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DPOW.Reader.Animation obj = dpow.getAnimation(treObjects.SelectedNode.Text);
            if (Clipboard.ContainsData("DPOWImage"))
            {
                DPOW.Reader.Image temp = (DPOW.Reader.Image)DeSerialize(Clipboard.GetData("DPOWImage").ToString());
                if (temp.TextureId >= dpow.Textures.Length)
                    temp.TextureId = 0;
                obj.getFrameOnTime(trcFrameBar.Value).Element.addImage(temp);
            }
            else if (Clipboard.ContainsData("DPOWText"))
                obj.getFrameOnTime(trcFrameBar.Value).Element.addText((DPOW.Reader.Text)DeSerialize(Clipboard.GetData("DPOWText").ToString()));
            else if (Clipboard.ContainsData("DPOWIcon"))
                obj.getFrameOnTime(trcFrameBar.Value).Element.addIcon((DPOW.Reader.Icon)DeSerialize(Clipboard.GetData("DPOWIcon").ToString()));

            drawFrame();
        }

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem.Contains("text"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("text", ""));
                if (dpow.Elements[k].Images[l].Points.Length != 4)
                {
                    MessageBox.Show("Scale is only applicable on Images with 4 points!");
                    return;
                }
                frmScaleDialog ScaleForm = new frmScaleDialog(dpow.Elements[k].Images[l]);
                ScaleForm.ShowDialog();
                drawFrame();
            }
            else
            {
                MessageBox.Show("Scale is only applicable on Images");
            }
        }

        private void timeLine1_SameKeyFrameAdded(DPOW.Reader.Animation animation, int Time)
        {
            animation.AddSameKeyFrame((short)Time);

            trcFrameBar.Maximum = dpow.getAnimation(treObjects.SelectedNode.Text).MaxTime;
        }

        private void flipHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem.Contains("text"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("text", ""));
                dpow.Elements[k].Images[l].FlipHorizontal();
            }
            else
            {
                MessageBox.Show("Only applicable in Images!");
            }
        }

        private void flipVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem.Contains("text"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("text", ""));
                dpow.Elements[k].Images[l].FlipVertical();
            }
            else
            {
                MessageBox.Show("Only applicable in Images!");
            }
        }

        private void uVMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem.Contains("text"))
            {
                int k = int.Parse(SelectedItem.Split('_')[0].Replace("Element", ""));
                int l = int.Parse(SelectedItem.Split('_')[1].Replace("text", ""));
                frmUVMapDialog UVMapForm = new frmUVMapDialog(dpow.Elements[k].Images[l], dpow.Textures[dpow.Elements[k].Images[l].TextureId]);
                UVMapForm.ShowDialog();
                drawFrame();
            }
            else
            {
                MessageBox.Show("Only applicable in Images!");
            }
        }

        private void loadFromFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgBrowser = new FolderBrowserDialog();
            if (dlgBrowser.ShowDialog() != DialogResult.OK)
                return;

            string dir = dlgBrowser.SelectedPath;
            for (int i = 0; i < dpow.Textures.Length; i++)
                if (File.Exists(dir + "\\" + dpow.Textures[i] + ".png"))
                {
                    createMaterial(dpow.Textures[i], System.Drawing.Image.FromFile(dir + "\\" + dpow.Textures[i] + ".png"));

                    imlTextures.Images.Add(dpow.Textures[i], System.Drawing.Image.FromFile(dir + "\\" + dpow.Textures[i] + ".png"));
                    lstTextures.Items[i].ImageKey = dpow.Textures[i];
                }

            lstTextures.Refresh();
        }

        private void mnuInterpolateAnimation_Click(object sender, EventArgs e)
        {
            frmInterpolateDialog InterpolateForm = new frmInterpolateDialog(dpow, dpow.getAnimation(treObjects.SelectedNode.Text));
            InterpolateForm.ShowDialog();
        }

        private void mnuInterpolate_Click(object sender, EventArgs e)
        {
            frmInterpolateDialog InterpolateForm = new frmInterpolateDialog(dpow);
            InterpolateForm.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showToolStripMenuItem.Checked = !showToolStripMenuItem.Checked;
            tmlMainTimeLine.ShowChildren = showToolStripMenuItem.Checked;
        }
    }
}
