namespace DPOWEditor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.duplicateSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.flipHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uVMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInterpolate = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSideView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.autoplayOnClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsOnTimelineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.treObjects = new System.Windows.Forms.TreeView();
            this.lstTextures = new System.Windows.Forms.ListView();
            this.ctxTextureMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imlTextures = new System.Windows.Forms.ImageList(this.components);
            this.trcFrameBar = new System.Windows.Forms.TrackBar();
            this.picRender = new System.Windows.Forms.PictureBox();
            this.prpProperties = new System.Windows.Forms.PropertyGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tmrPlay = new System.Windows.Forms.Timer(this.components);
            this.dlgOpenImage = new System.Windows.Forms.OpenFileDialog();
            this.lstVariables = new System.Windows.Forms.ListView();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.ctxPickObject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxAnimationMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAnimationAddChild = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInterpolateAnimation = new System.Windows.Forms.ToolStripMenuItem();
            this.tmlMainTimeLine = new TimeLineControl.FullTimeLine();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblPointer = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain.SuspendLayout();
            this.ctxTextureMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trcFrameBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRender)).BeginInit();
            this.ctxAnimationMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(1160, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBINToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openBINToolStripMenuItem
            // 
            this.openBINToolStripMenuItem.Name = "openBINToolStripMenuItem";
            this.openBINToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openBINToolStripMenuItem.Text = "Open BIN...";
            this.openBINToolStripMenuItem.Click += new System.EventHandler(this.openBINToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pastToolStripMenuItem,
            this.toolStripMenuItem2,
            this.duplicateSelectedToolStripMenuItem,
            this.toolStripMenuItem3,
            this.flipHorizontalToolStripMenuItem,
            this.flipVerticalToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pastToolStripMenuItem
            // 
            this.pastToolStripMenuItem.Name = "pastToolStripMenuItem";
            this.pastToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.pastToolStripMenuItem.Text = "Paste";
            this.pastToolStripMenuItem.Click += new System.EventHandler(this.pastToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 6);
            // 
            // duplicateSelectedToolStripMenuItem
            // 
            this.duplicateSelectedToolStripMenuItem.Name = "duplicateSelectedToolStripMenuItem";
            this.duplicateSelectedToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.duplicateSelectedToolStripMenuItem.Text = "Duplicate selected";
            this.duplicateSelectedToolStripMenuItem.Click += new System.EventHandler(this.duplicateSelectedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(167, 6);
            // 
            // flipHorizontalToolStripMenuItem
            // 
            this.flipHorizontalToolStripMenuItem.Name = "flipHorizontalToolStripMenuItem";
            this.flipHorizontalToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.flipHorizontalToolStripMenuItem.Text = "Flip Horizontal";
            this.flipHorizontalToolStripMenuItem.Click += new System.EventHandler(this.flipHorizontalToolStripMenuItem_Click);
            // 
            // flipVerticalToolStripMenuItem
            // 
            this.flipVerticalToolStripMenuItem.Name = "flipVerticalToolStripMenuItem";
            this.flipVerticalToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.flipVerticalToolStripMenuItem.Text = "Flip Vertical";
            this.flipVerticalToolStripMenuItem.Click += new System.EventHandler(this.flipVerticalToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleToolStripMenuItem,
            this.uVMapToolStripMenuItem,
            this.toolStripMenuItem6,
            this.mnuInterpolate});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.scaleToolStripMenuItem.Text = "Scale...";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.scaleToolStripMenuItem_Click);
            // 
            // uVMapToolStripMenuItem
            // 
            this.uVMapToolStripMenuItem.Name = "uVMapToolStripMenuItem";
            this.uVMapToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.uVMapToolStripMenuItem.Text = "UV map...";
            this.uVMapToolStripMenuItem.Click += new System.EventHandler(this.uVMapToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(137, 6);
            // 
            // mnuInterpolate
            // 
            this.mnuInterpolate.Name = "mnuInterpolate";
            this.mnuInterpolate.Size = new System.Drawing.Size(140, 22);
            this.mnuInterpolate.Text = "Interpolate...";
            this.mnuInterpolate.Click += new System.EventHandler(this.mnuInterpolate_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowIcons,
            this.mnuSideView,
            this.toolStripMenuItem5,
            this.autoplayOnClickToolStripMenuItem,
            this.eventsOnTimelineToolStripMenuItem,
            this.showToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // mnuShowIcons
            // 
            this.mnuShowIcons.CheckOnClick = true;
            this.mnuShowIcons.Name = "mnuShowIcons";
            this.mnuShowIcons.Size = new System.Drawing.Size(258, 22);
            this.mnuShowIcons.Text = "Show Icons";
            this.mnuShowIcons.Click += new System.EventHandler(this.mnuShowIcons_Click);
            // 
            // mnuSideView
            // 
            this.mnuSideView.CheckOnClick = true;
            this.mnuSideView.Name = "mnuSideView";
            this.mnuSideView.Size = new System.Drawing.Size(258, 22);
            this.mnuSideView.Text = "Side View";
            this.mnuSideView.Click += new System.EventHandler(this.mnuSideView_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(255, 6);
            // 
            // autoplayOnClickToolStripMenuItem
            // 
            this.autoplayOnClickToolStripMenuItem.Name = "autoplayOnClickToolStripMenuItem";
            this.autoplayOnClickToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.autoplayOnClickToolStripMenuItem.Text = "Autoplay on Click";
            this.autoplayOnClickToolStripMenuItem.Click += new System.EventHandler(this.autoplayOnClickToolStripMenuItem_Click);
            // 
            // eventsOnTimelineToolStripMenuItem
            // 
            this.eventsOnTimelineToolStripMenuItem.Name = "eventsOnTimelineToolStripMenuItem";
            this.eventsOnTimelineToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.eventsOnTimelineToolStripMenuItem.Text = "Hide inactive Events from Timeline";
            this.eventsOnTimelineToolStripMenuItem.Click += new System.EventHandler(this.eventsOnTimelineToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Checked = true;
            this.showToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.showToolStripMenuItem.Text = "Show Children on Timeline";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            // 
            // treObjects
            // 
            this.treObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treObjects.Location = new System.Drawing.Point(12, 27);
            this.treObjects.Name = "treObjects";
            this.treObjects.Size = new System.Drawing.Size(305, 429);
            this.treObjects.TabIndex = 3;
            this.treObjects.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treObjects_MouseClick);
            this.treObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treObjects_AfterSelect);
            // 
            // lstTextures
            // 
            this.lstTextures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTextures.ContextMenuStrip = this.ctxTextureMenu;
            this.lstTextures.LargeImageList = this.imlTextures;
            this.lstTextures.Location = new System.Drawing.Point(946, 462);
            this.lstTextures.Name = "lstTextures";
            this.lstTextures.Size = new System.Drawing.Size(214, 160);
            this.lstTextures.TabIndex = 2;
            this.lstTextures.UseCompatibleStateImageBehavior = false;
            // 
            // ctxTextureMenu
            // 
            this.ctxTextureMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.loadFromFolderToolStripMenuItem,
            this.addImageToolStripMenuItem});
            this.ctxTextureMenu.Name = "ctxTextureMenu";
            this.ctxTextureMenu.Size = new System.Drawing.Size(173, 70);
            this.ctxTextureMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxTextureMenu_Opening);
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.loadImageToolStripMenuItem.Text = "Load texture file...";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // loadFromFolderToolStripMenuItem
            // 
            this.loadFromFolderToolStripMenuItem.Name = "loadFromFolderToolStripMenuItem";
            this.loadFromFolderToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.loadFromFolderToolStripMenuItem.Text = "Load from folder...";
            this.loadFromFolderToolStripMenuItem.Click += new System.EventHandler(this.loadFromFolderToolStripMenuItem_Click);
            // 
            // addImageToolStripMenuItem
            // 
            this.addImageToolStripMenuItem.Name = "addImageToolStripMenuItem";
            this.addImageToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addImageToolStripMenuItem.Text = "Add texture...";
            this.addImageToolStripMenuItem.Click += new System.EventHandler(this.addImageToolStripMenuItem_Click);
            // 
            // imlTextures
            // 
            this.imlTextures.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlTextures.ImageSize = new System.Drawing.Size(128, 128);
            this.imlTextures.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // trcFrameBar
            // 
            this.trcFrameBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trcFrameBar.Location = new System.Drawing.Point(417, 411);
            this.trcFrameBar.Maximum = 30;
            this.trcFrameBar.Name = "trcFrameBar";
            this.trcFrameBar.Size = new System.Drawing.Size(523, 45);
            this.trcFrameBar.TabIndex = 4;
            this.trcFrameBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trcFrameBar.ValueChanged += new System.EventHandler(this.trcFrameBar_ValueChanged);
            // 
            // picRender
            // 
            this.picRender.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picRender.Cursor = System.Windows.Forms.Cursors.Default;
            this.picRender.Location = new System.Drawing.Point(323, 27);
            this.picRender.Name = "picRender";
            this.picRender.Size = new System.Drawing.Size(617, 378);
            this.picRender.TabIndex = 5;
            this.picRender.TabStop = false;
            this.picRender.Layout += new System.Windows.Forms.LayoutEventHandler(this.picRender_Layout);
            this.picRender.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picRender_MouseMove);
            this.picRender.Resize += new System.EventHandler(this.picRender_Resize);
            this.picRender.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picRender_MouseClick);
            this.picRender.Paint += new System.Windows.Forms.PaintEventHandler(this.picRender_Paint);
            // 
            // prpProperties
            // 
            this.prpProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prpProperties.Location = new System.Drawing.Point(946, 27);
            this.prpProperties.Name = "prpProperties";
            this.prpProperties.Size = new System.Drawing.Size(214, 429);
            this.prpProperties.TabIndex = 6;
            this.prpProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.prpProperties_PropertyValueChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button1.Location = new System.Drawing.Point(323, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "►";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button2.Location = new System.Drawing.Point(370, 411);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "■";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tmrPlay
            // 
            this.tmrPlay.Interval = 10;
            this.tmrPlay.Tick += new System.EventHandler(this.tmrPlay_Tick);
            // 
            // dlgOpenImage
            // 
            this.dlgOpenImage.Filter = "All supported files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|PNG Files" +
                " (*.png)|*.png";
            // 
            // lstVariables
            // 
            this.lstVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstVariables.CheckBoxes = true;
            this.lstVariables.Location = new System.Drawing.Point(12, 462);
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.Size = new System.Drawing.Size(305, 160);
            this.lstVariables.TabIndex = 9;
            this.lstVariables.UseCompatibleStateImageBehavior = false;
            this.lstVariables.View = System.Windows.Forms.View.List;
            this.lstVariables.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstVariables_ItemChecked);
            // 
            // ctxPickObject
            // 
            this.ctxPickObject.Name = "ctxPickObject";
            this.ctxPickObject.Size = new System.Drawing.Size(61, 4);
            // 
            // ctxAnimationMenu
            // 
            this.ctxAnimationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAnimationAddChild,
            this.removeToolStripMenuItem,
            this.toolStripMenuItem4,
            this.mnuInterpolateAnimation});
            this.ctxAnimationMenu.Name = "ctxAnimationMenu";
            this.ctxAnimationMenu.Size = new System.Drawing.Size(141, 76);
            this.ctxAnimationMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxAnimationMenu_Opening);
            // 
            // mnuAnimationAddChild
            // 
            this.mnuAnimationAddChild.Name = "mnuAnimationAddChild";
            this.mnuAnimationAddChild.Size = new System.Drawing.Size(140, 22);
            this.mnuAnimationAddChild.Text = "Add Child...";
            this.mnuAnimationAddChild.Click += new System.EventHandler(this.mnuAnimationAddChild_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(137, 6);
            // 
            // mnuInterpolateAnimation
            // 
            this.mnuInterpolateAnimation.Name = "mnuInterpolateAnimation";
            this.mnuInterpolateAnimation.Size = new System.Drawing.Size(140, 22);
            this.mnuInterpolateAnimation.Text = "Interpolate...";
            this.mnuInterpolateAnimation.Click += new System.EventHandler(this.mnuInterpolateAnimation_Click);
            // 
            // tmlMainTimeLine
            // 
            this.tmlMainTimeLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tmlMainTimeLine.CurrentFrame = 0;
            this.tmlMainTimeLine.HandleAnimationEvents = false;
            this.tmlMainTimeLine.Location = new System.Drawing.Point(323, 462);
            this.tmlMainTimeLine.Name = "tmlMainTimeLine";
            this.tmlMainTimeLine.SelectedAnimation = null;
            this.tmlMainTimeLine.ShowChildren = true;
            this.tmlMainTimeLine.Size = new System.Drawing.Size(617, 160);
            this.tmlMainTimeLine.TabIndex = 10;
            this.tmlMainTimeLine.KeyFrameRemoved += new TimeLineControl.FullTimeLine.KeyFrameEventHandler(this.timeLine1_KeyFrameRemoved);
            this.tmlMainTimeLine.FrameChanged += new TimeLineControl.FullTimeLine.FrameChangedEventHadler(this.timeLine1_FrameChanged);
            this.tmlMainTimeLine.ElementSelected += new TimeLineControl.FullTimeLine.ElementSelectedEventHandler(this.timeLine1_ElementSelected);
            this.tmlMainTimeLine.KeyFrameAdded += new TimeLineControl.FullTimeLine.KeyFrameEventHandler(this.timeLine1_KeyFrameAdded);
            this.tmlMainTimeLine.SameKeyFrameAdded += new TimeLineControl.FullTimeLine.KeyFrameEventHandler(this.timeLine1_SameKeyFrameAdded);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPointer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 627);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1160, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblPointer
            // 
            this.lblPointer.Name = "lblPointer";
            this.lblPointer.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 649);
            this.Controls.Add(this.tmlMainTimeLine);
            this.Controls.Add(this.lstVariables);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.prpProperties);
            this.Controls.Add(this.picRender);
            this.Controls.Add(this.trcFrameBar);
            this.Controls.Add(this.treObjects);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.lstTextures);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "DPOW Studio";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ctxTextureMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trcFrameBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRender)).EndInit();
            this.ctxAnimationMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBINToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.TreeView treObjects;
        private System.Windows.Forms.ListView lstTextures;
        private System.Windows.Forms.TrackBar trcFrameBar;
        private System.Windows.Forms.PictureBox picRender;
        private System.Windows.Forms.PropertyGrid prpProperties;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer tmrPlay;
        private System.Windows.Forms.ContextMenuStrip ctxTextureMenu;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ImageList imlTextures;
        private System.Windows.Forms.OpenFileDialog dlgOpenImage;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuShowIcons;
        private System.Windows.Forms.ToolStripMenuItem mnuSideView;
        private System.Windows.Forms.ListView lstVariables;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.ContextMenuStrip ctxPickObject;
        private TimeLineControl.FullTimeLine tmlMainTimeLine;
        private System.Windows.Forms.ContextMenuStrip ctxAnimationMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAnimationAddChild;
        private System.Windows.Forms.ToolStripMenuItem autoplayOnClickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsOnTimelineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uVMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuInterpolate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuInterpolateAnimation;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblPointer;
    }
}

