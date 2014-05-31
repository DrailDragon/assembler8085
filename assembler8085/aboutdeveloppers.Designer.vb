<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class aboutdeveloppers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(aboutdeveloppers))
        Me.developper_info_lbl = New System.Windows.Forms.Label()
        Me.AboutDeveloppers_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'developper_info_lbl
        '
        Me.developper_info_lbl.AutoEllipsis = True
        Me.developper_info_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.developper_info_lbl.ForeColor = System.Drawing.Color.DarkRed
        Me.developper_info_lbl.Location = New System.Drawing.Point(55, 204)
        Me.developper_info_lbl.Name = "developper_info_lbl"
        Me.developper_info_lbl.Size = New System.Drawing.Size(500, 175)
        Me.developper_info_lbl.TabIndex = 0
        Me.developper_info_lbl.Text = "Developped By :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Pintu Kumar 120101050" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Raja Kumar   120101055" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Babul Do" & _
    "lley  120101013 " & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Instructed By :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Dr. SANTOSH BISWAS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   "
        Me.developper_info_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AboutDeveloppers_Timer
        '
        Me.AboutDeveloppers_Timer.Interval = 30
        '
        'aboutdeveloppers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(591, 512)
        Me.Controls.Add(Me.developper_info_lbl)
        Me.Name = "aboutdeveloppers"
        Me.Text = "aboutdeveloppers"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents developper_info_lbl As System.Windows.Forms.Label
    Friend WithEvents AboutDeveloppers_Timer As System.Windows.Forms.Timer
End Class
