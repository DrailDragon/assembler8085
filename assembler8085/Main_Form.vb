Imports System
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Public Class Main_Form

    Private Sub Mian_Form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Mnemonic_DataBaseDataSet1.conversion' table. You can move, or remove it, as needed.
        Me.ConversionTableAdapter.Fill(Me.Mnemonic_DataBaseDataSet1.conversion)

    End Sub
    'new menustripitem(open new file)
    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If mainRichTxt.Text <> "" Then
            If MessageBox.Show("Do you want save the changes in the current file?", "assembler8085 Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If filepath.Text = "" Then
                    Dim mysaveFile As New SaveFileDialog()

                    ' Initialize the SaveFileDialog to specify the RTF extention for the file.
                    mysaveFile.DefaultExt = "*.macsm"
                    mysaveFile.Filter = "M.A.C.S.M Files|*.macsm"

                    ' Determine whether the user selected a file name from the saveFileDialog. 
                    If (mysaveFile.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
                        And (mysaveFile.FileName.Length > 0) Then

                        ' Save the contents of the mainRichTxt RichTextBox into the file.
                        mainRichTxt.SaveFile(mysaveFile.FileName, RichTextBoxStreamType.PlainText)
                        filepath_lbl.Visible = True
                        filepath.Text = mysaveFile.FileName

                    End If
                Else
                    mainRichTxt.SaveFile(filepath.Text, RichTextBoxStreamType.PlainText)


                End If
            End If
        End If
        'make global_tabcontrol visible and pop maineditor_tabpage
        global_TabControl.Visible = True
        Me.global_TabControl.SelectedTab = MainEditor_TabPage

        'make Mainpage_Panel visible
        Mainpage_Panel.Visible = True

        'make mainRichtxt readonly false
        mainRichTxt.ReadOnly = False


        'clear all richtextboxes
        mainRichTxt.Text = ""
        Error_RichTxt.Text = ""
        Corr8085_RichTxt.Text = ""
        AssembledCode_RichTxt.Text = ""
        Linked_Loaded_comp_RichTxt.Text = ""
        assembled_RichTxt.Text = ""
        assembled_RichTxt2.Text = ""
        Linked_LoadedRichTxt.Text = ""
        Linked_LoadedRichTxt2.Text = ""
        LinkingError_RichTxt.Text = ""
        '-----------------------
        ''----------------------------------------------
        ''make all tabpage_panels visible false
        ''--------------------------------
        ProgramData_panel.Visible = False
        Data8085mnem_panel.Visible = False

        ''--------------------------------
        AssembledData_Panel.Visible = False
        AssembledFile_panel.Visible = False
        Labels_add_panel.Visible = False

        '--------------------------------
        Linker_Loader_panel.Visible = False
        '--------------------------------

        filepath_lbl.Visible = False
        filepath.Text = ""
        'CONTROL FLOW SIGNAL RESET
        '--------------------------------
        control_flow_signals.maintxt_changed = 0
        control_flow_signals.ret_to_link = 0
        control_flow_signals.only_first_code_addr_needed = 0
        control_flow_signals.macro_exp_has_done = 0
        control_flow_signals.error_checked = 0
        control_flow_signals.asmbling_sec_file = 0
        control_flow_signals.linking_has_done = 0
        '----------------------------------
        Insert_sec_file_btn.Visible = True

        'clear textboxes
        '-------------------------
        Code1add_Txt.Text = ""
        Code2_Addr_Txt.Text = ""


        '--------------------------

    End Sub
    'open menustripitem(open an existing file)
    Private Sub OpenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        If myOpenFile.ShowDialog() = DialogResult.OK Then
            'clear all richtextboxes
            '-----------------------
            mainRichTxt.Text = ""
            Error_RichTxt.Text = ""
            Corr8085_RichTxt.Text = ""
            AssembledCode_RichTxt.Text = ""
            Linked_Loaded_comp_RichTxt.Text = ""
            assembled_RichTxt.Text = ""
            assembled_RichTxt2.Text = ""
            Linked_LoadedRichTxt.Text = ""
            Linked_LoadedRichTxt2.Text = ""
            LinkingError_RichTxt.Text = ""
            ' -----------------------

            ' ----------------------------------------------
            ' make all tag_page_panels visible false
            '--------------------------------
            ProgramData_panel.Visible = False
            Data8085mnem_panel.Visible = False

            '--------------------------------
            AssembledData_Panel.Visible = False
            AssembledFile_panel.Visible = False
            Labels_add_panel.Visible = False

            '--------------------------------
            Linker_Loader_panel.Visible = False
            '--------------------------------

            ' CONTROL FLOW SIGNAL RESET
            ' --------------------------------
            control_flow_signals.maintxt_changed = 0
            control_flow_signals.ret_to_link = 0
            control_flow_signals.only_first_code_addr_needed = 0
            control_flow_signals.macro_exp_has_done = 0
            control_flow_signals.error_checked = 0
            control_flow_signals.asmbling_sec_file = 0
            '----------------------------------

            Insert_sec_file_btn.Visible = True

            'clear textboxes
            '-------------------------
            Code1add_Txt.Text = ""
            Code2_Addr_Txt.Text = ""


            filepath_lbl.Visible = True
            Mainpage_Panel.Visible = True
            mainRichTxt.Visible = True
            filepath.Text = myOpenFile.FileName
            mainRichTxt.Text = File.ReadAllText(myOpenFile.FileName)




        End If
    End Sub
    ' save menustripitem
    Private Sub SaveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If filepath.Text = "" Then
            Dim mysaveFile As New SaveFileDialog()

            ' Initialize the SaveFileDialog to specify the RTF extention for the file.
            mysaveFile.DefaultExt = "*.macsm"
            mysaveFile.Filter = "M.A.C.S.M Files|*.macsm"

            ' Determine whether the user selected a file name from the saveFileDialog. 
            If (mysaveFile.ShowDialog() = System.Windows.Forms.DialogResult.OK) And (mysaveFile.FileName.Length > 0) Then

                ' Save the contents of the RichTextBox into the file.
                mainRichTxt.SaveFile(mysaveFile.FileName, RichTextBoxStreamType.PlainText)
                filepath_lbl.Visible = True
                filepath.Text = mysaveFile.FileName

            End If
        Else
            mainRichTxt.SaveFile(filepath.Text, RichTextBoxStreamType.PlainText)

        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        ' Create a SaveFileDialog to request a path and file name to save to. 
        Dim mysaveAsFile As New SaveFileDialog()

        ' Initialize the SaveFileDialog to specify the RTF extention for the file.
        mysaveAsFile.DefaultExt = "*.macsm"
        mysaveAsFile.Filter = "M.A.C.S.M Files|*.macsm"

        ' Determine whether the user selected a file name from the saveFileDialog. 
        If (mysaveAsFile.ShowDialog() = System.Windows.Forms.DialogResult.OK) And (mysaveAsFile.FileName.Length > 0) Then

            ' Save the contents of the RichTextBox into the file.
            mainRichTxt.SaveFile(mysaveAsFile.FileName, RichTextBoxStreamType.PlainText)
            filepath_lbl.Visible = True
            filepath.Text = mysaveAsFile.FileName

        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If mainRichTxt.Text <> "" Then
            Dim result = MessageBox.Show("Do you want save the changes in the current file?", "assembler8085 Project", _
         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If filepath.Text = "" Then
                    Dim mysaveFile As New SaveFileDialog()

                    ' Initialize the SaveFileDialog to specify the RTF extention for the file.
                    mysaveFile.DefaultExt = "*.macsm"
                    mysaveFile.Filter = "M.A.C.S.M Files|*.macsm"

                    ' Determine whether the user selected a file name from the saveFileDialog. 
                    If (mysaveFile.ShowDialog() = System.Windows.Forms.DialogResult.OK) And (mysaveFile.FileName.Length > 0) Then

                        ' Save the contents of the RichTextBox into the file.
                        mainRichTxt.SaveFile(mysaveFile.FileName, _
                                              RichTextBoxStreamType.PlainText)
                        filepath_lbl.Visible = True
                        filepath.Text = mysaveFile.FileName

                    End If
                Else
                    mainRichTxt.SaveFile(filepath.Text, RichTextBoxStreamType.PlainText)

                End If
                Application.Exit()
            ElseIf result = DialogResult.No Then
                Application.Exit()
            End If



        Else

            If MessageBox.Show("Do you really want to exit?", "assembler8085 Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Application.Exit()
            End If

        End If

    End Sub

    Private Sub Main_Form_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If mainRichTxt.Text <> "" Then
            Dim result = MessageBox.Show("Do you want save the changes in the current file?", "assembler8085 Project", _
         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If filepath.Text = "" Then
                    Dim mysaveFile As New SaveFileDialog()

                    ' Initialize the SaveFileDialog to specify the RTF extention for the file.
                    mysaveFile.DefaultExt = "*.macsm"
                    mysaveFile.Filter = "M.A.C.S.M Files|*.macsm"

                    ' Determine whether the user selected a file name from the saveFileDialog. 
                    If (mysaveFile.ShowDialog() = System.Windows.Forms.DialogResult.OK) And (mysaveFile.FileName.Length > 0) Then

                        ' Save the contents of the RichTextBox into the file.
                        mainRichTxt.SaveFile(mysaveFile.FileName, RichTextBoxStreamType.PlainText)
                        filepath_lbl.Visible = True
                        filepath.Text = mysaveFile.FileName

                    End If
                Else
                    mainRichTxt.SaveFile(filepath.Text, RichTextBoxStreamType.PlainText)

                End If
                Application.Exit()
            ElseIf result = DialogResult.No Then
                Application.Exit()
            End If



        Else

            If MessageBox.Show("Do you really want to exit?", "assembler8085 Project", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Application.Exit()
            End If

        End If
    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    'Line numbers on side of textboxe1(main editor) using pictureboxes
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub DrawRichTextBoxLineNumbers(ByRef g As Graphics)
        'Calculate font heigth as the difference in Y coordinate 
        'between line 2 and line 1
        'Note that the RichTextBox text must have at least two lines. 
        '  So the initial Text property of the RichTextBox 
        '  should not be an empty string. It could be something 
        '  like vbcrlf & vbcrlf & vbcrlf 
        With mainRichTxt
            Dim font_height As Single

            font_height = mainRichTxt.Font.GetHeight()


            'Get the first line index and location
            Dim first_index As Integer
            Dim first_line As Integer
            Dim first_line_y As Integer
            first_index = .GetCharIndexFromPosition(New Point(0, g.VisibleClipBounds.Y + font_height / 3))
            first_line = .GetLineFromCharIndex(first_index)
            first_line_y = .GetPositionFromCharIndex(first_index).Y

            'Print on the PictureBox the visible line numbers of the RichTextBox
            g.Clear(Control.DefaultBackColor)
            Dim i As Integer = first_line
            Dim y As Single
            Do While y < g.VisibleClipBounds.Y + g.VisibleClipBounds.Height
                y = first_line_y + 2 + font_height * (i - first_line - 1)
                g.DrawString((i).ToString, .Font, Brushes.DarkBlue, mainRichtxt_line_numpb.Width _
                      - g.MeasureString((i).ToString, .Font).Width, y)
                i += 1
            Loop
            'Debug.WriteLine("Finished: " & firstLine + 1 & " " & i - 1)
        End With
    End Sub

    'show about developpers
    Private Sub DeveloppersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeveloppersToolStripMenuItem.Click
        Me.Hide()
        aboutdeveloppers.ShowDialog()
    End Sub
    'paint the line numbers  on left of the mainrichtextbox
    Private Sub mainRichTxt_VScroll(sender As System.Object, e As System.EventArgs) Handles mainRichTxt.VScroll
        mainRichtxt_line_numpb.Invalidate()
    End Sub
    'paint the line numbers  on left of the mainrichtextbox
    Private Sub mainRichTxt_Resize(sender As System.Object, e As System.EventArgs) Handles mainRichTxt.Resize
        mainRichtxt_line_numpb.Invalidate()
    End Sub
    'paint the line numbers  on left of the mainrichtextbox
    Private Sub mainRichtxt_line_numpb_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles mainRichtxt_line_numpb.Paint
        DrawRichTextBoxLineNumbers(e.Graphics)
    End Sub
    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    ' decimal-hexadecimal conversion
    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    Private Sub convert_btn_Click(sender As System.Object, e As System.EventArgs) Handles convert_btn.Click
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        If decimal_Txt.Text.Length * Hexadecimal_Txt.Text.Length <> 0 Then
            MessageBox.Show("One of the entries among Decimal and Hexa-Decimal must be empty", "ALL Project", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            globalVars.hexstring = Hexadecimal_Txt.Text
            globalVars.decstring = decimal_Txt.Text

            globalVars.hexstring = globalVars.hexstring.ToUpper

            For index As Integer = 0 To globalVars.hexstring.Length() - 1
                If (Not (((Asc(globalVars.hexstring.Chars(index)) >= 48) And (Asc(globalVars.hexstring.Chars(index)) <= 57)) Or ((Asc(globalVars.hexstring.Chars(index)) >= 65) And (Asc(globalVars.hexstring.Chars(index)) <= 70)))) Then
                    MessageBox.Show("Improper Hexa-Decimal Format", "ALL Project", _
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
                    globalVars.iscorrect = False
                End If

            Next


            For index As Integer = 0 To globalVars.decstring.Length() - 1
                If (Not (((Asc(globalVars.decstring.Chars(index)) >= 48) And (Asc(globalVars.decstring.Chars(index)) <= 57)))) Then
                    MessageBox.Show("Improper Decimal Format", "ALL Project", _
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
                    globalVars.iscorrect = False
                End If

            Next





            If globalVars.iscorrect = True Then
                If globalVars.hexstring.Length > 0 Then

                    decimal_Txt.Text = CLng("&H" & globalVars.hexstring)

                Else

                    Dim decD As Double = Convert.ToDouble(globalVars.decstring)
                    Hexadecimal_Txt.Text = Conversion.Hex(decD)

                End If
            Else
                globalVars.iscorrect = True
            End If
        End If
    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    ' error check before assembling
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub Error_Check_btn_Click(sender As System.Object, e As System.EventArgs) Handles Error_Check_btn.Click
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        'control flow signals checks macro expansion was done 
        'before or not and after macro expansion was done was 
        'the text changed
        'if the text was changed give error and ask to do macro expansion again
        If control_flow_signals.macro_exp_has_done = 1 And control_flow_signals.maintxt_changed = 0 Then
            globalVars.error_status = 0         'for checking error status of pass2

            control_flow_signals.macro_exp_has_done = 0
            control_flow_signals.error_checked = 1

            globalVars.pass0()                  'go for proper synataxing of code


            'Pass 1 takes out the varibles and labels from the code
            'and put it in the table.
            If globalVars.pass1() = -1 Then     'returns -1 if 1st pass gives error

                'if pass1 returns error
                'clear rich textbox 3
                'and variable and label tables

                Corr8085_RichTxt.Text = ""
                var_addr_val_Datagridview.Rows.Clear()
                label_addr_Datagridview.Rows.Clear()
                Exit Sub
            End If

            'Pass 2 replaces the labels with proper 
            '8085 insructions.

            globalVars.pass2()
            If globalVars.error_status = -1 Then

                'id pass 2 returns error
                'if pass1 returns error
                'clear rich textbox 3
                'and variable and label tables

                Corr8085_RichTxt.Text = ""
                var_addr_val_Datagridview.Rows.Clear()                       'clear var_addr_val_Datagridview table
                label_addr_Datagridview.Rows.Clear()                       'clear label_addr_Datagridview table
                Exit Sub
            End If


            control_flow_signals.macro_exp_has_done = 0
            control_flow_signals.error_checked = 1
            control_flow_signals.maintxt_changed = 0

            ProgramData_panel.Visible = True
            Data8085mnem_panel.Visible = True
            Corr8085_RichTxt.Text += "HLT"                  'append hlt at the end of code
            Error_RichTxt.Text = "No Errors found program processsed..."  'write no errors found in the error report box

        Else

            'if macro exapnsion button is not clicked
            'then put error and exit sub
            Error_RichTxt.Text = "Press macro expand button first"
            Exit Sub


        End If

    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    'Assemble button handler
    'to assemble the code
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub Assemble_btn_Click(sender As System.Object, e As System.EventArgs) Handles Assemble_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        'check if both the macro expansion and error check has been done
        'if not then give error
        If (control_flow_signals.error_checked = 1) And (control_flow_signals.maintxt_changed = 0) Then


            'AssembledData_TabPage show 
            Me.global_TabControl.SelectedTab = AssembledData_TabPage

            'make big panel 4 visible true
            AssembledData_TabControl.Visible = True
            AssembledData_Panel.Visible = True

            'clear rtb4 rtb5 and lable_info table for new values.
            AssembledCode_RichTxt.Text = ""
            Linked_Loaded_comp_RichTxt.Text = ""
            label_info_DataGridView.Rows.Clear()


            'import 8085 code from Corr8085_RichTxt in form1
            Me.AssembledCode_RichTxt.Text = Me.Corr8085_RichTxt.Text



            'Assembler pass1 gets the address of the labels
            assemble_functions.assemble_pass1()

            'Assembler pass2 replaces the occurences of the labels 
            assemble_functions.assemble_pass2()

            'make error check done zero again
            control_flow_signals.error_checked = 0




            'check which file were you assembling original file or external dependent file
            If control_flow_signals.asmbling_sec_file = 1 Then

                'make assemble second file button visible false
                Insert_sec_file_btn.Visible = False

                'make Code1Add_panel for address input visible true
                Code1Add_panel.Visible = True

                'make panel10 visible true
                Code2_Addr_Panel.Visible = True




            End If


            'if no external dependencies in original file then
            If control_flow_signals.extrn_has_found = 0 Then

                If control_flow_signals.asmbling_sec_file = 0 Then
                    Code1Add_panel.Visible = True
                    Code2_Addr_Panel.Visible = False

                    control_flow_signals.only_first_code_addr_needed = 1

                Else
                    Code1Add_panel.Visible = True
                    Code2_Addr_Panel.Visible = True
                    control_flow_signals.only_first_code_addr_needed = 0


                End If
            Else

                If control_flow_signals.asmbling_sec_file = 0 Then
                    Code1Add_panel.Visible = False
                    Code2_Addr_Panel.Visible = False
                End If


            End If

            'make tab2.visible true
            AssembledData_TabControl.Visible = True

            'make sub big panel1  visible true
            AssembledFile_panel.Visible = True

            'make sub big panel2 visible true
            Labels_add_panel.Visible = True

        Else
            Error_RichTxt.Text = "Error checking not done or text changed..."
        End If

    End Sub




    Private Sub InstructionSet_panel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles InstructionSet_panel.Paint

    End Sub

    Private Sub Delete_Macro_btn_Click(sender As System.Object, e As System.EventArgs) Handles Delete_Macro_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        Dim index As Integer            'for iterating over the array list

        Dim search As String = Macro_ComboBox.Text       'store the macro name to be searched for

        Dim obj As macro_codes = New macro_codes()        'declares a new object of class macro_codes for storing the element of the arraylist stored at position index
        Dim found As Boolean = False                'default value of succesful search initialized to false

        For index = 0 To globalVars.macros.ToArray.Length - 1       'iterate over complete arraylist

            obj = CType(globalVars.macros(index), macro_codes)         'box the generic object with the object of type macro_codes

            If search = obj.getMacro Then                           'if match is found, obj.getMacro accesses the "macro name" property of the macro object


                globalVars.macros.Remove(obj)                       'delete the macro object from the arraylist if found


                ' MessageBox.Show(obj.getCode)
                found = True                                        'Macro Deletion Successful
                Exit For
                'End Sub
            Else


            End If

            'If obj.
            'If search = globalVars.macros(i).m Then

        Next

        Dim result As MsgBoxResult

        If found = True Then

            result = MsgBox("Are you sure you want to delete " + obj.getMacro + " macro", MsgBoxStyle.YesNo, "Delete " + obj.getMacro + " macro")

            If result = MsgBoxResult.Yes Then

                Try

                    globalVars.macros.Remove(obj)                       'delete the macro object from the arraylist if found
                    Macro_ComboBox.Items.RemoveAt(Macro_ComboBox.FindStringExact(Macro_ComboBox.Text))     'Removes the macro name from the combobox as well


                    MessageBox.Show("Macro Deleted Succesfuly")                 'Displays the success message

                Catch ex As Exception

                    MsgBox("An Error Occured, We highly recommend you to close the project and restart it again", MsgBoxStyle.OkOnly, "Error Message")

                    'if at all some error occurs
                End Try

            Else


            End If



        Else

            MessageBox.Show("No Macro Found")                           'Displays the failure of search/deletion
        End If




    End Sub


    Private Sub LinkingError_RichTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles LinkingError_RichTxt.TextChanged

    End Sub

    Private Sub Linker_Loader_panel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Linker_Loader_panel.Paint

    End Sub


    Private Sub ProgramData_panel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles ProgramData_panel.Paint

    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    ' Macro Related Button Handlors
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub Add_New_Macro_btn_Click(sender As System.Object, e As System.EventArgs) Handles Add_New_Macro_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        Me.Hide()       'hide the present form and display the macro form for adding the macro
        AddMacroForm.Show()

    End Sub

    Private Sub View_Macro_Code_btn_Click(sender As System.Object, e As System.EventArgs) Handles View_Macro_Code_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        Dim index As Integer

        Dim search As String = Macro_ComboBox.Text

        Dim obj As macro_codes = New macro_codes()
        Dim found As Boolean = False

        For index = 0 To globalVars.macros.ToArray.Length - 1

            obj = CType(globalVars.macros(index), macro_codes)

            If search = obj.getMacro Then

                '        MessageBox.Show(obj.getCode)
                found = True
                Exit For
                'End Sub
            Else


            End If

            'If obj.
            'If search = globalVars.macros(i).m Then

        Next

        If found = True Then
            'Set the properties of the AddMacroForm form if the desired macro is found
            AddMacroForm.macName.Text = obj.getMacro
            AddMacroForm.parc1.Text = obj.getArg1
            AddMacroForm.parc2.Text = obj.getArg2
            AddMacroForm.parc3.Text = obj.getArg3
            AddMacroForm.code.Text = obj.getCode

            'Disable the components making them view only
            AddMacroForm.macName.Enabled = False
            AddMacroForm.parc1.Enabled = False
            AddMacroForm.parc2.Enabled = False
            AddMacroForm.parc3.Enabled = False
            AddMacroForm.code.Enabled = False
            AddMacroForm.Button1.Visible = False
            AddMacroForm.Button1.Enabled = False
            AddMacroForm.Text = "View Macro Code"

            Me.Hide()   'hide the present form and show the AddMacroForm(macro form)
            AddMacroForm.Show()

        Else

            MessageBox.Show("No Macro Found")
        End If

    End Sub
    'For saving loaded code1 into file
    Private Sub SaveLoaded_Code1_btn_Click(sender As System.Object, e As System.EventArgs) Handles SaveLoaded_Code1_btn.Click
        Dim saveFile1 As New SaveFileDialog()

        ' Initialize the SaveFileDialog to specify the RTF extention for the file.
        saveFile1.DefaultExt = "*.asm"
        saveFile1.Filter = "ASM Files|*.asm"

        ' Determine whether the user selected a file name from the saveFileDialog. 
        If (saveFile1.ShowDialog() = System.Windows.Forms.DialogResult.OK) And (saveFile1.FileName.Length > 0) Then

            ' Save the contents of the RichTextBox into the file.
            Linked_LoadedRichTxt.SaveFile(saveFile1.FileName, _
                                  RichTextBoxStreamType.PlainText)

        End If
    End Sub
    'For saving Loaded code2 into file
    Private Sub SaveLoaded_Code2_btn_Click(sender As System.Object, e As System.EventArgs) Handles SaveLoaded_Code2_btn.Click
        Dim saveFile1 As New SaveFileDialog()

        ' Initialize the SaveFileDialog to specify the RTF extention for the file.
        saveFile1.DefaultExt = "*.asm"
        saveFile1.Filter = "ASM Files|*.asm"

        ' Determine whether the user selected a file name from the saveFileDialog. 
        If (saveFile1.ShowDialog() = System.Windows.Forms.DialogResult.OK) And (saveFile1.FileName.Length > 0) Then

            ' Save the contents of the RichTextBox into the file.
            Linked_LoadedRichTxt2.SaveFile(saveFile1.FileName, _
                                  RichTextBoxStreamType.PlainText)

        End If
    End Sub

    Private Sub InstructionSetToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InstructionSetToolStripMenuItem.Click
        Help.Show()
    End Sub

    Private Sub ExpandMacro_btn_Click(sender As System.Object, e As System.EventArgs) Handles ExpandMacro_btn.Click

        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        globalVars.pass0()
        globalVars.pass1()
        globalVars.passmacro()
        globalVars.pass0()

        'control flow logic
        'if text was changed then reset it to 0
        'put macro exapansion done to 1
        control_flow_signals.macro_exp_has_done = 1
        control_flow_signals.maintxt_changed = 0
        control_flow_signals.error_checked = 0
        Error_RichTxt.Text = "Macro expansion done press Error check button....."

    End Sub
    '################################################################################################################################

    'rich textbox text changed
    '################################################################################################################################

    Private Sub mainRichTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles mainRichTxt.TextChanged
        control_flow_signals.maintxt_changed = 1
    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    'builtin macros Shortcut instruction keys
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    Private Sub ADC_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADC_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        '-------------------------------------------------------------
        builtin_macrosform.ADC_Panel.Visible = True
        ButtonFlowSignals.Which_Button_clicked = 14
        builtin_macrosform.ShowDialog()
        '-------------------------------------------------------------
    End Sub

    Private Sub ADD_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADD_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 7
        builtin_macrosform.ShowDialog()
        '-------------------------------------------------------------
    End Sub

    Private Sub ADDMM_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADDMM_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------

        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 9
        builtin_macrosform.ShowDialog()
        '-------------------------------------------------------------
    End Sub

    Private Sub ADI_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADI_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 8
        builtin_macrosform.ShowDialog()
        '-------------------------------------------------------------

    End Sub

    Private Sub JNZ_btn_Click(sender As System.Object, e As System.EventArgs) Handles JNZ_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 10
        builtin_macrosform.ShowDialog()
        '-------------------------------------------------------------

    End Sub

    Private Sub LDA_btn_Click(sender As System.Object, e As System.EventArgs) Handles LDA_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 3
        builtin_macrosform.ShowDialog()

        '-------------------------------------------------------------
    End Sub

    Private Sub LXI_btn_Click(sender As System.Object, e As System.EventArgs) Handles LXI_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 4
        builtin_macrosform.ShowDialog()
        '-------------------------------------------------------------

    End Sub

    Private Sub MOV_btn_Click(sender As System.Object, e As System.EventArgs) Handles MOV_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        builtin_macrosform.MOV_Panel.Visible = True
        ButtonFlowSignals.Which_Button_clicked = 15
        builtin_macrosform.ShowDialog()

    End Sub

    Private Sub MVIM_btn_Click(sender As System.Object, e As System.EventArgs) Handles MVIM_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 2
        builtin_macrosform.ShowDialog()

        '-------------------------------------------------------------

    End Sub

    Private Sub MVIR_btn_Click(sender As System.Object, e As System.EventArgs) Handles MVIR_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        builtin_macrosform.MVIR_Panel.Visible = True
        ButtonFlowSignals.Which_Button_clicked = 1
        builtin_macrosform.ShowDialog()

        '-------------------------------------------------------------
    End Sub

    Private Sub SBB_btn_Click(sender As System.Object, e As System.EventArgs) Handles SBB_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 12
        builtin_macrosform.ShowDialog()

    End Sub

    Private Sub SBI_btn_Click(sender As System.Object, e As System.EventArgs) Handles SBI_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        ButtonFlowSignals.Which_Button_clicked = 13
        builtin_macrosform.ShowDialog()
    End Sub

    Private Sub SHLD_btn_Click(sender As System.Object, e As System.EventArgs) Handles SHLD_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 6
        builtin_macrosform.ShowDialog()
        '-------------------------------------------------------------

    End Sub

    Private Sub STA_btn_Click(sender As System.Object, e As System.EventArgs) Handles STA_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 5
        builtin_macrosform.ShowDialog()
        '-------------------------------------------------------------

    End Sub

    Private Sub JMP_btn_Click(sender As System.Object, e As System.EventArgs) Handles JMP_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        '-------------------------------------------------------------

        ButtonFlowSignals.Which_Button_clicked = 11
        builtin_macrosform.ShowDialog()
        '-------------------------------------------------------------


    End Sub
    'Insert second file to link button_click handler
    Private Sub Insert_sec_file_btn_Click(sender As System.Object, e As System.EventArgs) Handles Insert_sec_file_btn.Click

        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.linking_has_done = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------

        'put the contents of assembled code in a string
        assembled_contents.assembled_code1 = Linked_Loaded_comp_RichTxt.Text



        If control_flow_signals.extrn_has_found = 1 Then

            'clear all text boxes
            '--------------------------------------------
            mainRichTxt.Text = ""
            Error_RichTxt.Text = ""
            Corr8085_RichTxt.Text = ""
            AssembledCode_RichTxt.Text = ""
            Linked_Loaded_comp_RichTxt.Text = ""
            assembled_RichTxt.Text = ""
            assembled_RichTxt2.Text = ""
            Linked_LoadedRichTxt.Text = ""
            Linked_LoadedRichTxt2.Text = ""
            LinkingError_RichTxt.Text = ""
            '---------------------------------------------

            'clear all tables
            '---------------------------------------------
            var_addr_val_Datagridview.Rows.Clear()
            label_addr_Datagridview.Rows.Clear()
            extern_Datagridview.Rows.Clear()
            label_info_DataGridView.Rows.Clear()
            '---------------------------------------------

            'show tabpage 1
            Me.global_TabControl.SelectedTab = MainEditor_TabPage

            'change control flow signals
            control_flow_signals.asmbling_sec_file = 1
            control_flow_signals.extrn_has_found = 0

        Else

            'no external dependencies
            MessageBox.Show("There are no external dependencies proceed to load")


        End If





    End Sub

    Private Sub Link_load_btn_Click(sender As System.Object, e As System.EventArgs) Handles Link_load_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.asmbling_sec_file = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        If control_flow_signals.asmbling_sec_file = 0 Then

            assembled_contents.assembled_code1 = Linked_Loaded_comp_RichTxt.Text

        End If

        'TAKE THE INPUT VALUES OF ADDRESSES FROM THE USER FOR LOADING IN TEXT BOXES AND DIPLAY ERRORS

        '============================================================================================
        Try
            Int(Code1add_Txt.Text)
        Catch ex As Exception

            If Code1Add_panel.Visible = True Then
                MessageBox.Show("Give proper integer address for code1.")
            Else
                MessageBox.Show("give proper file to link")
            End If

            Exit Sub

        End Try
        If control_flow_signals.only_first_code_addr_needed = 0 Then
            Try
                Int(Code2_Addr_Txt.Text)
            Catch ex As Exception
                MessageBox.Show("Give proper integer address for code2.")
                Exit Sub


            End Try
        End If
        '================================================================
        Start_Addr2_lbl.Text = Code2_Addr_Txt.Text
        Start_Addr_lbl.Text = Code1add_Txt.Text
        'select LinkerAndLoader_TabPage
        Me.Global_TabControl.SelectedTab = LinkerAndLoader_TabPage

        'make Linker_loader_panel visible
        Me.Linker_Loader_panel.Visible = True

        'clear  richtextboxes
        '-----------------------
        assembled_RichTxt.Text = ""
        assembled_RichTxt2.Text = ""
        Linked_LoadedRichTxt.Text = ""
        Linked_LoadedRichTxt2.Text = ""
        LinkingError_RichTxt.Text = ""
        '-----------------------



        'show the original file contents in assembled_RichTxt
        assembled_RichTxt.Text = assembled_contents.assembled_code1
        'MessageBox.Show(assembled_contents.assembled_code1)






        'show the second code in assembled_RichTxt2
        assembled_RichTxt2.Text = Linked_Loaded_comp_RichTxt.Text

        'check if second code is there
        If control_flow_signals.only_first_code_addr_needed = 0 Then

            'if yes proceed to pass 2
            load_functions.loadcode2_pass1()
        End If

        'do load code 1
        Dim code1_pass_check As Integer

        code1_pass_check = load_functions.loadcode1_pass1()

        If code1_pass_check = -1 Then

            control_flow_signals.maintxt_changed = 0
            control_flow_signals.ret_to_link = 0
            control_flow_signals.only_first_code_addr_needed = 0
            control_flow_signals.macro_exp_has_done = 0
            control_flow_signals.error_checked = 0
            control_flow_signals.asmbling_sec_file = 1
            control_flow_signals.asmbling_sec_file = 0
            assembled_RichTxt.Text = ""
            assembled_RichTxt2.Text = ""
            Linked_LoadedRichTxt.Text = ""
            Linked_LoadedRichTxt2.Text = ""

            Exit Sub



        End If


        If control_flow_signals.only_first_code_addr_needed = 1 Then
            assembled_RichTxt2.Text = ""
            Linked_LoadedRichTxt2.Text = ""
            SaveLoaded_Code2_btn.Visible = False
            LinkingError_RichTxt.Text = "File loaded Successfully... "
        Else
            LinkingError_RichTxt.Text = "Files linked and loaded Successfully... "
            SaveLoaded_Code2_btn.Visible = True

        End If

        mainRichTxt.ReadOnly = True


        control_flow_signals.asmbling_sec_file = 1 
    End Sub

    Private Sub Link_continous_btn_Click(sender As System.Object, e As System.EventArgs) Handles Link_continous_btn.Click
        'check if linking has occured earlier
        '-------------------------------------------------------------
        If control_flow_signals.asmbling_sec_file = 1 Then
            MessageBox.Show("Linking already done start new project")
            Exit Sub

        End If
        '-------------------------------------------------------------
        If control_flow_signals.asmbling_sec_file = 0 Then

            assembled_contents.assembled_code1 = Linked_Loaded_comp_RichTxt.Text

        End If

        'TAKE THE INPUT VALUES OF ADDRESSES FROM THE USER FOR LOADING IN TEXT BOXES AND DIPLAY ERRORS

        '============================================================================================
        Try
            Int(Code1add_Txt.Text)
        Catch ex As Exception

            If Code1Add_panel.Visible = True Then
                MessageBox.Show("Give proper integer address for code1.")
            Else
                MessageBox.Show("give proper file to link")
            End If

            Exit Sub

        End Try

        '================================================================

        Code2_Addr_Txt.Text = Convert.ToString(assembled_contents.Location_counter_value + 1 + CInt(Code1add_Txt.Text))
        If control_flow_signals.only_first_code_addr_needed = 1 Then
            MessageBox.Show("No second file required click on normal linkin button")
            Exit Sub
        End If
        MessageBox.Show("The starting point of second code would be  = " + Code2_Addr_Txt.Text)
        Start_Addr2_lbl.Text = Code2_Addr_Txt.Text
        Start_Addr_lbl.Text = Code1add_Txt.Text

        'select LinkerAndLoader_TabPage
        Me.global_TabControl.SelectedTab = LinkerAndLoader_TabPage

        'make bigpanel5 visible
        Me.Linker_Loader_panel.Visible = True

        'clear  richtextboxes
        '-----------------------
        assembled_RichTxt.Text = ""
        assembled_RichTxt2.Text = ""
        Linked_LoadedRichTxt.Text = ""
        Linked_LoadedRichTxt2.Text = ""
        LinkingError_RichTxt.Text = ""
        '-----------------------

        'show the original file contents in rich textbox 6
        assembled_RichTxt.Text = assembled_contents.assembled_code1
        'MessageBox.Show(assembled_contents.assembled_code1)
        'show the second code in assembled_RichTxt2
        assembled_RichTxt2.Text = Linked_Loaded_comp_RichTxt.Text

        'check if second code is there
        If control_flow_signals.only_first_code_addr_needed = 0 Then

            'if yes proceed to pass 2
            load_functions.loadcode2_pass1()
        End If

        'do load code 1
        Dim code1_pass_check As Integer

        code1_pass_check = load_functions.loadcode1_pass1()

        If code1_pass_check = -1 Then

            control_flow_signals.maintxt_changed = 0
            control_flow_signals.ret_to_link = 0
            control_flow_signals.only_first_code_addr_needed = 0
            control_flow_signals.macro_exp_has_done = 0
            control_flow_signals.error_checked = 0
            control_flow_signals.asmbling_sec_file = 1
            control_flow_signals.asmbling_sec_file = 0
            assembled_RichTxt.Text = ""
            assembled_RichTxt2.Text = ""
            Linked_LoadedRichTxt.Text = ""
            Linked_LoadedRichTxt2.Text = ""

            Exit Sub

        End If
        If control_flow_signals.only_first_code_addr_needed = 1 Then
            assembled_RichTxt2.Text = ""
            Linked_LoadedRichTxt2.Text = ""
            SaveLoaded_Code2_btn.Visible = False
            LinkingError_RichTxt.Text = "File loaded Successfully... "
        Else
            LinkingError_RichTxt.Text = "Files linked and loaded Successfully... "
            SaveLoaded_Code2_btn.Visible = True

        End If

        mainRichTxt.ReadOnly = True
        control_flow_signals.asmbling_sec_file = 1

    End Sub
End Class

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
'CONTROL FLOW SIGNALS
'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Public Class control_flow_signals
    Public Shared ret_to_link As Integer = 0
    Public Shared macro_exp_has_done = 0
    Public Shared maintxt_changed = 0
    Public Shared extrn_has_found = 0
    Public Shared error_checked = 0
    Public Shared asmbling_sec_file = 0
    Public Shared only_first_code_addr_needed = 0
    Public Shared linking_has_done = 0
End Class
'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
'Global var function for error chaecking progrdure and macro expansion procedure
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXxxxxxxxx

Public Class globalVars


    '####################################
    'Shared variables
    '####################################

    Public Shared hexstring As String
    Public Shared iscorrect As Boolean = True
    Public Shared decstring As String
    Public Shared lineerror_pass2 As Integer
    Public Shared error_status As Integer = 0
    Public Shared macros As ArrayList = New ArrayList()

    'XXXXXXXXXXXXXXXXXXXXXXXX
    'pass new line function
    'XXXXXXXXXXXXXXXXXXXXXXXX
    Public Shared Function passnewline() As Integer

        Dim str As String = Main_Form.mainRichTxt.Text

        Main_Form.mainRichTxt.Text = ""        'clear mainRichTxt
        ' Split string based on spaces
        Dim lines As String() = Regex.Split(str, "\n")
        Dim line As String

        For Each line In lines

            Main_Form.mainRichTxt.Text += line + vbNewLine
        Next

        Return 1
    End Function

    'XXXXXXXXXXXXXXXXXXXXXXXXXX


    'XXXXXXXXXXXXXXXXXXXXXXXXXXXX
    'Macro related function
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXX

    'pass macro function
    Public Shared Function passmacro() As Integer

        Dim str As String = Main_Form.mainRichTxt.Text

        Main_Form.mainRichTxt.Text = ""        'clear mainRichTxt
        ' Split string based on spaces
        Dim lines As String() = Regex.Split(str, "\n")
        Dim line As String
        Dim wordno As Integer = 0
        Dim lineerror As Integer = 1
        Dim flagnewline As Integer = 0
        For Each line In lines
            flagnewline = 0
            wordno = 0
            Dim words As String() = Regex.Split(line, " ")  'spilt words on basis of spaces
            ' Dim word As String

            wordno = 0
            While wordno < words.Length

                Dim i As Integer

                Dim search_macro As String = words.ElementAt(wordno)

                Dim macro_obj As macro_codes = New macro_codes()
                Dim macro_found As Boolean = False

                For i = 0 To globalVars.macros.ToArray.Length - 1

                    macro_obj = CType(globalVars.macros(i), macro_codes)

                    If search_macro = macro_obj.getMacro Then

                        'MessageBox.Show(macro_obj.getCode)
                        macro_found = True
                        Exit For
                        'End Sub
                    Else


                    End If

                    'If macro_obj.
                    'If search_macro = globalVars.macros(i).m Then

                Next

                If macro_found = True Then

                    Dim argno As Integer = macro_obj.getArgs
                    If (wordno + argno + 1) <> words.Length Then

                        MessageBox.Show("Invalid number of arguments to macro " + macro_obj.getMacro)
                        errorfunction("Invalid number of arguments to macro " + macro_obj.getMacro, lineerror)
                        Return -1
                    Else
                        Dim checkargno As Integer = 1
                        Dim arg1 As String = ""
                        Dim arg2 As String = ""
                        Dim arg3 As String = ""

                        If argno = 1 Or argno = 2 Or argno = 3 Then

                            If macro_obj.getArg1 = "R1" Then

                                If words.ElementAt(wordno + 1).ToUpper <> "A" And words.ElementAt(wordno + 1).ToUpper <> "H" And words.ElementAt(wordno + 1).ToUpper <> "L" Then

                                    MessageBox.Show("Invalid argument1 type to macro " + macro_obj.getMacro)

                                    errorfunction("Invalid argument1(must be a register) to macro " + macro_obj.getMacro, lineerror)
                                    Return -1
                                Else
                                    arg1 = words.ElementAt(wordno + 1)
                                End If

                            ElseIf macro_obj.getArg1 = "C1" Then
                                Dim arI As Integer
                                Dim inStr As String = words.ElementAt(wordno + 1)

                                Try
                                    arI = CInt(inStr)
                                    arg1 = inStr


                                Catch ex As Exception

                                    Try
                                        Dim arH As Integer
                                        arH = CLng("&H" & inStr.Substring(0, inStr.Length - 1))
                                        arg1 = inStr


                                    Catch ex1 As Exception
                                        MessageBox.Show("Invalid argument1 type to macro " + macro_obj.getMacro)
                                        errorfunction("Invalid argument1(must be a constant) to macro " + macro_obj.getMacro, lineerror)
                                        Return -1

                                    End Try
                                    'errorfunction("Invalid argument1(must be a register) to macro " + macro_obj.getMacro, lineerror)
                                    ' Return -1

                                End Try



                            ElseIf macro_obj.getArg1 = "M1" Then

                                Dim rowno As Integer = 0
                                Dim flagvar As Integer = 0
                                Dim flagextern As Integer = 0
                                While rowno < Main_Form.var_addr_val_Datagridview.RowCount

                                    If words.ElementAt(wordno + 1) = Main_Form.var_addr_val_Datagridview.Rows(rowno).Cells(0).Value Then
                                        flagvar = 1
                                        arg1 = words.ElementAt(wordno + 1)
                                        Exit While
                                    End If
                                    rowno += 1
                                End While

                                If flagvar = 0 Then
                                    rowno = 0
                                    Dim externvarcheck As String = Main_Form.extern_Datagridview.Rows(rowno).Cells(0).Value

                                    While rowno < Main_Form.extern_Datagridview.RowCount
                                        externvarcheck = Main_Form.extern_Datagridview.Rows(rowno).Cells(0).Value
                                        If words.ElementAt(wordno + 1) = externvarcheck Then
                                            flagextern = 1
                                            arg1 = words.ElementAt(wordno + 1)
                                            Exit While
                                        End If
                                        rowno += 1
                                    End While

                                End If


                                If flagvar = 0 And flagextern = 0 Then
                                    MessageBox.Show("Invalid argument1 type to macro " + macro_obj.getMacro)
                                    errorfunction("Invalid argument1(must be a variable) to macro " + macro_obj.getMacro, lineerror)
                                    Return -1
                                End If




                            End If


                        End If

                        If argno = 2 Or argno = 3 Then

                            If macro_obj.getArg2 = "R2" Then

                                If words.ElementAt(wordno + 2).ToUpper <> "A" And words.ElementAt(wordno + 2).ToUpper <> "H" And words.ElementAt(wordno + 2).ToUpper <> "L" Then
                                    MessageBox.Show("Invalid argument2 type to macro " + macro_obj.getMacro)
                                    errorfunction("Invalid argument2(must be a register) to macro " + macro_obj.getMacro, lineerror)
                                    Return -1
                                Else
                                    arg2 = words.ElementAt(wordno + 2)

                                End If

                            ElseIf macro_obj.getArg2 = "C2" Then
                                Dim arI As Integer
                                Dim inStr As String = words.ElementAt(wordno + 2)

                                Try
                                    arI = CInt(inStr)
                                    arg2 = inStr


                                Catch ex As Exception

                                    Try
                                        Dim arH As Integer
                                        arH = CLng("&H" & inStr.Substring(0, inStr.Length - 1))
                                        arg2 = inStr


                                    Catch ex1 As Exception
                                        MessageBox.Show("Invalid argument2 type to macro " + macro_obj.getMacro)
                                        errorfunction("Invalid argument1(must be a constant) to macro " + macro_obj.getMacro, lineerror)
                                        Return -1

                                    End Try


                                    'errorfunction("Invalid argument1(must be a register) to macro " + macro_obj.getMacro, lineerror)
                                    ' Return -1

                                End Try




                            ElseIf macro_obj.getArg2 = "M2" Then

                                Dim rowno As Integer = 0
                                Dim flagvar As Integer = 0
                                Dim flagextern As Integer = 0
                                While rowno < Main_Form.var_addr_val_Datagridview.RowCount

                                    If words.ElementAt(wordno + 2) = Main_Form.var_addr_val_Datagridview.Rows(rowno).Cells(0).Value Then
                                        flagvar = 1
                                        arg2 = words.ElementAt(wordno + 2)
                                        Exit While
                                    End If
                                    rowno += 1
                                End While

                                If flagvar = 0 Then
                                    rowno = 0
                                    Dim externvarcheck As String = Main_Form.extern_Datagridview.Rows(rowno).Cells(0).Value

                                    While rowno < Main_Form.extern_Datagridview.RowCount
                                        externvarcheck = Main_Form.extern_Datagridview.Rows(rowno).Cells(0).Value
                                        If words.ElementAt(wordno + 2) = externvarcheck Then
                                            flagextern = 1
                                            arg2 = words.ElementAt(wordno + 2)
                                            Exit While
                                        End If
                                        rowno += 1
                                    End While

                                End If

                                If flagvar = 0 And flagextern = 0 Then
                                    MessageBox.Show("Invalid argument2 type to macro " + macro_obj.getMacro)
                                    errorfunction("Invalid argument2(must be a variable) to macro " + macro_obj.getMacro, lineerror)
                                    Return -1
                                End If




                            End If

                        End If

                        If argno = 3 Then
                            If macro_obj.getArg3 = "R3" Then

                                If words.ElementAt(wordno + 3).ToLower <> "a" And words.ElementAt(wordno + 3).ToLower <> "h" And words.ElementAt(wordno + 3).ToLower <> "l" Then

                                    MessageBox.Show("Invalid argument3 type to macro " + macro_obj.getMacro)
                                    errorfunction("Invalid argument3(must be a register) to macro " + macro_obj.getMacro, lineerror)
                                    Return -1
                                Else
                                    arg3 = words.ElementAt(wordno + 3)
                                End If


                            ElseIf macro_obj.getArg3 = "C3" Then
                                Dim arI As Integer
                                Dim inStr As String = words.ElementAt(wordno + 3)

                                Try
                                    arI = CInt(inStr)
                                    arg3 = inStr


                                Catch ex As Exception

                                    Try
                                        Dim arH As Integer
                                        arH = CLng("&H" & inStr.Substring(0, inStr.Length - 1))
                                        arg3 = inStr


                                    Catch ex1 As Exception
                                        MessageBox.Show("Invalid argument3 type to macro " + macro_obj.getMacro)
                                        errorfunction("Invalid argument1(must be a constant) to macro " + macro_obj.getMacro, lineerror)
                                        Return -1

                                    End Try

                                    'errorfunction("Invalid argument1(must be a constant) to macro " + macro_obj.getMacro, lineerror)
                                    'Return -1

                                End Try


                            ElseIf macro_obj.getArg3 = "M3" Then

                                Dim rowno As Integer = 0
                                Dim flagvar As Integer = 0
                                Dim flagextern As Integer = 0
                                While rowno < Main_Form.var_addr_val_Datagridview.RowCount

                                    If words.ElementAt(wordno + 3) = Main_Form.var_addr_val_Datagridview.Rows(rowno).Cells(0).Value Then
                                        flagvar = 1
                                        arg3 = words.ElementAt(wordno + 3)
                                        Exit While
                                    End If
                                    rowno += 1
                                End While

                                If flagvar = 0 Then
                                    rowno = 0
                                    Dim externvarcheck As String = Main_Form.extern_Datagridview.Rows(rowno).Cells(0).Value

                                    While rowno < Main_Form.extern_Datagridview.RowCount
                                        externvarcheck = Main_Form.extern_Datagridview.Rows(rowno).Cells(0).Value
                                        If words.ElementAt(wordno + 3) = externvarcheck Then
                                            flagextern = 1
                                            arg3 = words.ElementAt(wordno + 3)
                                            Exit While
                                        End If
                                        rowno += 1
                                    End While

                                End If

                                If flagvar = 0 And flagextern = 0 Then
                                    MessageBox.Show("Invalid argument1 type to macro " + macro_obj.getMacro)
                                    errorfunction("Invalid argument3(must be a variable) to macro " + macro_obj.getMacro, lineerror)
                                    Return -1
                                End If



                            End If


                        End If
                        flagnewline = 1
                        expandmacro(arg1, arg2, arg3, i)
                    End If


                    Exit While

                Else
                    Main_Form.mainRichTxt.Text += search_macro + " "
                    'MessageBox.Show("No Macro Found")
                End If

                wordno += 1
            End While


            lineerror += 1
            If flagnewline = 0 Then
                Main_Form.mainRichTxt.Text += vbNewLine
            End If


        Next

        Return 1
    End Function

    'expand macro function
    Public Shared Function expandmacro(ByVal arg1, ByVal arg2, ByVal arg3, ByVal index) As Integer
        Dim macro_obj As macro_codes = New macro_codes()

        macro_obj = CType(globalVars.macros(index), macro_codes)

        Dim macrocode As String = macro_obj.getCode

        Dim lines As String() = Regex.Split(macrocode, "\n")
        Dim line As String
        Dim wordno As Integer = 0
        Dim lineerror As Integer = 1
        For Each line In lines
            wordno = 0
            Dim words As String() = Regex.Split(line, " ")  'spilt words on basis of spaces
            Dim word As String
            For Each word In words

                If word = macro_obj.getArg1 And macro_obj.getArg1 <> "" Then
                    Main_Form.mainRichTxt.Text += arg1 + " "
                ElseIf word = macro_obj.getArg2 And macro_obj.getArg2 <> "" Then
                    Main_Form.mainRichTxt.Text += arg2 + " "
                ElseIf word = macro_obj.getArg3 And macro_obj.getArg3 <> "" Then
                    Main_Form.mainRichTxt.Text += arg3 + " "
                Else
                    Main_Form.mainRichTxt.Text += word + " "

                End If

            Next
            Main_Form.mainRichTxt.Text += vbNewLine
        Next

        Return 1
    End Function


    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    'error check function pass0 pass1 pass2
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    Public Shared Function pass0() As Integer

        Dim str As String = Main_Form.mainRichTxt.Text

        Main_Form.mainRichTxt.Text = ""        'clear mainRichTxt
        ' Split string based on spaces
        Dim lines As String() = Regex.Split(str, "\n")
        Dim line As String
        Dim lineflag As Integer = 0
        Dim spaceflag As Integer = 0
        For Each line In lines
            Dim words As String() = Regex.Split(line, " ")  'spilt words on basis of spaces
            Dim word As String
            spaceflag = 0
            For Each word In words

                If word <> "" And spaceflag = 0 And lineflag = 0 Then

                    Main_Form.mainRichTxt.Text += word
                    spaceflag = 1
                    lineflag = 1

                ElseIf word <> "" And spaceflag = 0 And lineflag = 1 Then
                    Main_Form.mainRichTxt.Text += vbNewLine
                    Main_Form.mainRichTxt.Text += word
                    spaceflag = 1

                ElseIf word <> "" And spaceflag = 1 And lineflag = 1 Then
                    Main_Form.mainRichTxt.Text += " " + word

                End If


            Next



        Next

        Return 0
    End Function

    Public Shared Function pass1() As Integer
        'clear both the compilation error region and the assembly code region before starting pass1
        Main_Form.Error_RichTxt.Text = ""
        Main_Form.Corr8085_RichTxt.Text = ""

        Main_Form.var_addr_val_Datagridview.Rows.Clear()
        Main_Form.label_addr_Datagridview.Rows.Clear()
        Main_Form.extern_Datagridview.Rows.Clear()


        Dim compile As Integer = 0      'for checking if pass 1 is successful
        Main_Form.Corr8085_RichTxt.Visible = True
        Dim str As String = Main_Form.mainRichTxt.Text     'take in text of Code1add_Txt
        ' Split string based on \n
        Dim lines As String() = Regex.Split(str, "\n")
        Dim line As String
        Dim lineerror As Integer = 1    'for printing line no of error
        Dim lineno As Integer = 0
        For Each line In lines          'going through each line of the code
            If line = "" Then
                Continue For
            End If
            'printing which line is being processed
            Main_Form.Error_RichTxt.Text = "Error while processing this line ... " + vbNewLine
            Main_Form.Error_RichTxt.Text += line + vbNewLine



            lineno += 1
            Dim wordno As Integer = 1
            Dim words As String() = Regex.Split(line, " ")  ' Split string based on spaces
            Dim word As String



            If words.ElementAt(0) = "" Then
                errorfunction("Stray space(s) at the beginning.", lineerror)
                Return -1
            End If
            If words.ElementAt(0).ElementAt(0) = ";" Then
                Continue For
            End If


            If lineno = 1 Then      'for checking if the start is at the beginning of code
                Dim flag1 As Integer = 0
                Dim i As Integer = 0
                For Each word In words      'loop for checking if syntax of start is correct
                    If flag1 = 1 And word <> "" Then
                        Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ": " + word + "should not be there after START." + vbNewLine
                        Main_Form.Corr8085_RichTxt.Text = ""
                        Return (-1)
                        Exit Function
                    End If
                    If word = "" And flag1 = 0 Then
                        i += 1
                        Continue For
                    ElseIf word.ToUpper <> "START" And flag1 = 0 Then   'error if code does not begin with start
                        Main_Form.Error_RichTxt.Text = "Line No " & lineerror & ": Code should begin with START statement." + vbNewLine
                        Return (-1)
                        Exit Function
                    ElseIf flag1 = 0 Then
                        'Main_Form.Corr8085_RichTxt.Text += word.ToUpper()
                        flag1 = 1
                    End If
                Next
                If i = words.Length And flag1 = 0 Then      'check again for start if 1st line contains blanks
                    lineno = 0
                    Continue For
                End If

            Else

                'checking for extern variables
                If words.ElementAt(0).ToLower = "extern" Then
                    If words.Length <> 2 Then       'format is extern $var1
                        errorfunction("Only name of a variable must be followed by extern keyword.", lineerror)
                        Return -1
                    Else
                        Dim var As String
                        var = words.ElementAt(1)
                        'checking syntax of variable
                        If var.ElementAt(0) <> "%" Or var.ElementAt(var.Length - 1) = ":" Then
                            errorfunction("Invalid syntax of variable after extern.", lineerror)
                            Return -1
                        Else
                            'adding extren variables to extern table
                            Main_Form.extern_Datagridview.Rows.Add(New String() {var})
                            Continue For

                        End If






                    End If

                End If



                For Each word In words
                    If word = "" Then   'checking for blank spaces
                        Continue For
                    End If






                    If word.ToUpper = "START" Or word.ToUpper = "$START" Or word.ToUpper = "START:" Then          'check if 2nd start is there
                        Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ": Start cannot be used multiple times." + vbNewLine
                        Main_Form.Corr8085_RichTxt.Text = ""
                        Return (-1)
                    Else
                        If globalVars.reservedwords(word, lineerror) = -1 Then
                            Main_Form.Corr8085_RichTxt.Text = ""
                            Return (-1)
                        End If

                    End If
                    Dim wordtype As Integer
                    If wordno = 1 Then

                        wordtype = globalVars.wordCheck(word, lineerror)        'function for checking if word is correct
                        If wordtype = 1 Then        'syntax checking for variable

                            If words.Length <> 3 Then
                                Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ": Invalid syntax for variable" + vbNewLine
                                Main_Form.Corr8085_RichTxt.Text = ""
                                Return (-1)
                                Exit Function

                            ElseIf words.ElementAt(1) <> "=" Then
                                Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ": Variable must be followed by = (seperated by space) " + vbNewLine
                                Main_Form.Corr8085_RichTxt.Text = ""
                                Return (-1)
                                Exit Function
                            Else
                                Dim lastword As String = words.ElementAt(2)
                                'for checking both decimal and hex nos
                                If lastword(lastword.Length - 1) = "h" Then 'for checking hex no
                                    Dim arg1 As String = lastword
                                    Dim arg1num

                                    arg1num = arg1.Substring(0, arg1.Length - 1)
                                    Dim dec As Integer
                                    Try
                                        dec = CLng("&H" & arg1num)      'hex checking function

                                        If Not (dec >= 0 And dec <= 255) Then
                                            Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ": Hex Number must be between 0 to FF. " + vbNewLine
                                            Main_Form.Corr8085_RichTxt.Text = ""
                                            Return (-1)

                                        End If

                                        If Asc(arg1.ToUpper.ElementAt(0)) >= 65 And Asc(arg1.ToUpper.ElementAt(0)) <= 70 Then
                                            arg1 = "0" + arg1       'add 0 to beginning if 1st char is A-F
                                        End If
                                        'add new row to var_addr_val_Datagridview table
                                        Main_Form.var_addr_val_Datagridview.Rows.Add(New String() {word.Substring(1, word.Length - 1), -1, arg1})
                                    Catch ex As Exception
                                        Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ": Variable must be decimal or hex number only. " + vbNewLine
                                        Main_Form.Corr8085_RichTxt.Text = ""
                                        Return (-1)
                                        Exit Function
                                    End Try


                                Else
                                    Try
                                        'if no is decimal
                                        Dim dec As Integer = Int(lastword.Substring(0, lastword.Length))

                                        If Not (dec >= 0 And dec <= 255) Then
                                            Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ": Decimal Number must be between 0 to 255. " + vbNewLine
                                            Main_Form.Corr8085_RichTxt.Text = ""
                                            Return (-1)

                                        End If

                                        Main_Form.var_addr_val_Datagridview.Rows.Add(New String() {word.Substring(1, word.Length - 1), -1, lastword})
                                    Catch ex As Exception
                                        Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ": Variable must be decimal or hex number only. " + vbNewLine
                                        Main_Form.Corr8085_RichTxt.Text = ""
                                        Return (-1)
                                        Exit Function
                                    End Try

                                End If

                            End If


                        ElseIf wordtype = -1 Then       'if word is of error type
                            compile = 1
                        ElseIf wordtype = 2 Then        'word is a label
                            Dim wordcheck As String = word.Substring(0, word.Length - 1)
                            Dim c As Char
                            'label can have only small alphabets and numbers
                            For Each c In wordcheck
                                If Not ((Asc(c) >= 97 And Asc(c) <= 122) Or (Asc(c) >= 48 And Asc(c) <= 57)) Then
                                    Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ":  Invalid Label syntax  " + vbNewLine
                                    Main_Form.Corr8085_RichTxt.Text = ""
                                    Return (-1)
                                    Exit Function
                                End If
                            Next
                            'add row to label table
                            Main_Form.label_addr_Datagridview.Rows.Add(New String() {wordcheck, -1})
                        End If

                    Else
                        ' Main_Form.Corr8085_RichTxt.Text += word + " "
                    End If
                    wordno += 1
                Next
            End If
            'Main_Form.Corr8085_RichTxt.Text += vbnewline
            lineerror += 1
        Next
        If compile = 0 Then
            ' Main_Form.Error_RichTxt.Text = "Compilation is successful."
        End If

        Return (1)
    End Function

    Public Shared Function pass2() As Integer
        Dim startcounter As Integer = 0
        Dim str As String = Main_Form.mainRichTxt.Text
        ' Split string based on spaces
        Dim lines As String() = Regex.Split(str, "\n")
        Dim line As String
        lineerror_pass2 = 1

        For Each line In lines

            If line = "" Then
                Continue For
            End If
            'printing which line is being processed
            Main_Form.Error_RichTxt.Text = "Error while processing this line ... " + vbNewLine
            Main_Form.Error_RichTxt.Text += line + vbNewLine
            Dim words As String() = Regex.Split(line, " ")  'spilt words on basis of spaces

            If words.ElementAt(0).ElementAt(0) = ";" Then   'check if line is a comment 
                Continue For
            End If

            Dim word As String
            word = words.ElementAt(0)
            If word = "" Then   'if blank continue
                Continue For
            ElseIf word(0) = "$" Then   'if $ continue
                Continue For

            ElseIf word = "extern" Then 'if beginning with extern

                'if an extern variable is present in the preogram
                'this should generate a signal
                If control_flow_signals.asmbling_sec_file = 0 Then
                    control_flow_signals.extrn_has_found = 1
                    Continue For
                Else
                    globalVars.errorfunction("Extern cannot be declared in second file", lineerror_pass2)
                    Return 0
                End If




                'on seeing start we add the variables
            ElseIf word.ToUpper() = "START" Then
                If startcounter = 0 Then
                    Main_Form.Corr8085_RichTxt.Text = "jmp start" + vbNewLine
                    startcounter = 1
                    varinsert()     'adding varibles
                Else
                    errorfunction("START declared more than once.", lineerror_pass2)    'check if start is declared twice
                End If

                'for lable put nop after it
            ElseIf word(word.Length - 1) = ":" Then
                Main_Form.Corr8085_RichTxt.Text += word + " nop" + vbNewLine

                If words.Length <> 1 Then
                    If keyword(words, 1) = 0 Then   'keyword checking function with startindex=0 as 1st index is already label
                        Return 0

                    End If

                End If

            Else

                If keyword(words, 0) = 0 Then       'keyword checking function with startindex=0

                    Return 0

                End If

            End If


            lineerror_pass2 += 1    'incrementing line no for error finding
        Next
        Return 0
    End Function

    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    '----------------------------------
    'error function to display errors
    '----------------------------------
    Public Shared Function errorfunction(ByVal errorstring, ByVal lineerror) As Integer
        'printing error
        Main_Form.Error_RichTxt.Text += "Line no " & lineerror & ": " + errorstring
        Main_Form.Corr8085_RichTxt.Text = ""
        error_status = -1
        Return 0
    End Function

    '-------------------------------------------------
    'insert var function to insert variable in table
    '------------------------------------------------

    Public Shared Function varinsert() As Integer
        Main_Form.Corr8085_RichTxt.Text += ";data" + vbNewLine
        Dim rowno As Integer = 0
        'take input from var_addr_val_Datagridview table and print in the data section
        While rowno < Main_Form.var_addr_val_Datagridview.RowCount
            If Main_Form.var_addr_val_Datagridview.Rows(rowno).Cells(0).Value <> "" Then
                Main_Form.Corr8085_RichTxt.Text += Main_Form.var_addr_val_Datagridview.Rows(rowno).Cells(0).Value + ": db" + " " + Main_Form.var_addr_val_Datagridview.Rows(rowno).Cells(2).Value + vbNewLine
            End If

            rowno += 1
        End While
        Main_Form.Corr8085_RichTxt.Text += ";code" + vbNewLine + "start: nop" + vbNewLine   'then print code section


        Return 0
    End Function

    '--------------------------------------------------

    '-------------------------------------------------
    'keyword function to returns keyword type
    '------------------------------------------------

    Public Shared Function keyword(ByRef words(), ByVal startindex) As Integer


        Dim rowno As Integer = 0
        Dim flag As Integer = 0
        Dim keywordpresent As Integer = 0

        If words.ElementAt(startindex).ToString.ToUpper() = "ADDMM" Then    'if keyword = ADDMM

            If words.Length <> (startindex + 4) Then    'checking no of arguments
                errorfunction("There should be 3 arguments.", lineerror_pass2)
                Return 0
            Else

                Dim index As Integer = 1
                While index <= 3

                    If words.ElementAt(startindex + index).ToString.ElementAt(0) = "%" Then

                        flag = 0
                        Dim rowno1 As Integer = 0
                        Dim flag1 As Integer = 0
                        'if all 3 varibles are present or not
                        While rowno1 < Main_Form.extern_Datagridview.RowCount
                            If words.ElementAt(startindex + index).ToString = Main_Form.extern_Datagridview.Rows(rowno1).Cells(0).Value Then
                                flag = 1
                                Exit While

                            End If
                            rowno1 += 1
                        End While
                        If flag = 1 Then

                        Else
                            errorfunction("Give valid variable(may be extern) as argument" & (index + 1), lineerror_pass2)
                            Return 0
                        End If


                    Else
                        flag = 0
                        Dim rowno1 As Integer = 0
                        Dim flag1 As Integer = 0
                        'if all 3 varibles are present or not
                        While rowno1 < Main_Form.var_addr_val_Datagridview.RowCount
                            If words.ElementAt(startindex + index).ToString = Main_Form.var_addr_val_Datagridview.Rows(rowno1).Cells(0).Value Then
                                flag = 1
                                Exit While

                            End If
                            rowno1 += 1
                        End While
                        If flag = 1 Then

                        Else
                            errorfunction("Give valid variable as argument" & (index + 1), lineerror_pass2)
                            Return 0
                        End If


                    End If
                    index += 1
                End While
                'instruction for ADDMM (defined by us)
                Main_Form.Corr8085_RichTxt.Text += "MOV b , a" + vbNewLine + "LDA " + words.ElementAt(startindex + 2) + vbNewLine + "MOV c , a" + vbNewLine + "LDA " + words.ElementAt(startindex + 3) + vbNewLine + "ADC c" + vbNewLine + "STA " + words.ElementAt(startindex + 1) + vbNewLine + "MOV a , b" + vbNewLine
                keywordpresent = 1
                Return 1

            End If

        End If

        If words.ElementAt(startindex).ToString.ToUpper() = "MVIM" Then     'if keyword = MVIM

            If words.Length <> (startindex + 3) Then
                errorfunction("There should be 2 arguments.", lineerror_pass2)  'checking no of arguments
                Return 0
            Else


                If words.ElementAt(startindex + 1).ToString.ElementAt(0) = "%" Then

                    flag = 0
                    Dim rowno1 As Integer = 0
                    Dim flag1 As Integer = 0
                    'if all 3 varibles are present or not
                    While rowno1 < Main_Form.extern_Datagridview.RowCount
                        If words.ElementAt(startindex + 1).ToString = Main_Form.extern_Datagridview.Rows(rowno1).Cells(0).Value Then
                            flag = 1
                            Exit While

                        End If
                        rowno1 += 1
                    End While
                    If flag = 1 Then

                    Else
                        errorfunction("Give valid variable(may be extern) as argument1", lineerror_pass2)
                        Return 0
                    End If

                Else

                    flag = 0
                    Dim rowno1 As Integer = 0
                    Dim flag1 As Integer = 0
                    'if 1st arg is variable or not
                    While rowno1 < Main_Form.var_addr_val_Datagridview.RowCount
                        If words.ElementAt(startindex + 1).ToString = Main_Form.var_addr_val_Datagridview.Rows(rowno1).Cells(0).Value Then
                            flag = 1
                            Exit While

                        End If
                        rowno1 += 1
                    End While
                    If flag = 1 Then

                    Else
                        errorfunction("Give valid variable as argument1", lineerror_pass2)
                        Return 0
                    End If

                End If





                'if 2nd arg is number or not
                Dim arg1 As String = words.ElementAt(startindex + 2).ToString
                Dim arg1num As String
                'check fro hex number
                If arg1(arg1.Length - 1) = "h" Then
                    arg1num = arg1.Substring(0, arg1.Length - 1)
                    Dim dec As Integer
                    Try
                        dec = CLng("&H" & arg1num)

                        If Not (dec >= 0 And dec <= 255) Then
                            errorfunction("The hex number as argument2 must be between 0 to FF.", lineerror_pass2)
                            Return 0

                        End If

                        If Asc(arg1.ToUpper.ElementAt(0)) >= 65 And Asc(arg1.ToUpper.ElementAt(0)) <= 70 Then
                            arg1 = "0" + arg1
                        End If

                        keywordpresent = 1
                    Catch ex As Exception
                        errorfunction("There should be a proper number as argument2.", lineerror_pass2)
                        Return 0
                    End Try

                Else
                    'check for hex number
                    arg1num = arg1

                    Try
                        Dim dec As Integer
                        dec = Int(arg1num)

                        If Not (dec >= 0 And dec <= 255) Then
                            errorfunction("The decimal number as argument2 must be between 0 to 255.", lineerror_pass2)
                            Return 0

                        End If

                        keywordpresent = 1
                    Catch ex As Exception
                        errorfunction("There should be a number as argument2.", lineerror_pass2)
                        Return 0

                    End Try



                End If

                'instruction for MVIM (defined by us)

                Main_Form.Corr8085_RichTxt.Text += "MOV b , a" + vbNewLine + "MVI a " + arg1 + vbNewLine + "STA " + words.ElementAt(startindex + 1) + vbNewLine + "MOV a , b" + vbNewLine
                keywordpresent = 1
                Return 1

            End If

        End If

        If words.ElementAt(startindex).ToString.ToUpper() = "LXI" Then     'if keyword = LXI
            If words.Length <> (startindex + 3) Then
                errorfunction("There should be only 2 arguments.", lineerror_pass2)  'checking no of arguments
                Return 0
            Else
                If words.ElementAt(startindex + 1).ToString <> "h" Then
                    errorfunction("Argument 1 has to be h.", lineerror_pass2)  'checking 1st argument
                    Return 0

                End If

                'if 2nd arg is number or not
                Dim arg1 As String = words.ElementAt(startindex + 2).ToString
                Dim arg1num As String
                'check for hex number
                If arg1(arg1.Length - 1) = "h" Then
                    arg1num = arg1.Substring(0, arg1.Length - 1)
                    Dim dec As Integer
                    Try
                        dec = CLng("&H" & arg1num)

                        If Not (dec >= 0 And dec <= 255) Then
                            errorfunction("The hex number as argument2 must be between 0 to FF.", lineerror_pass2)
                            Return 0

                        End If
                        If Asc(arg1.ToUpper.ElementAt(0)) >= 65 And Asc(arg1.ToUpper.ElementAt(0)) <= 70 Then
                            arg1 = "0" + arg1
                        End If

                        keywordpresent = 1
                    Catch ex As Exception
                        errorfunction("There should be a proper number as argument2.", lineerror_pass2)
                        Return 0
                    End Try

                Else
                    'check for hex number
                    arg1num = arg1

                    Try

                        Dim dec As Integer
                        dec = Int(arg1num)

                        If Not (dec >= 0 And dec <= 255) Then
                            errorfunction("The decimal number as argument2 must be between 0 to 255.", lineerror_pass2)
                            Return 0

                        End If

                        keywordpresent = 1
                    Catch ex As Exception
                        errorfunction("There should be a number as argument2.", lineerror_pass2)
                        Return 0

                    End Try


                End If

                Main_Form.Corr8085_RichTxt.Text += "LXI h , " + arg1 + vbNewLine
                Return 1
            End If


        End If


        'check for correct keyword is there
        While rowno < 23
            If words.ElementAt(startindex).ToString.ToUpper() = Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(0).Value Then
                If Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(3).Value = "0" Then    'if arg no is 0
                    If words.Length <> 1 Then
                        errorfunction("There should be no argument.", lineerror_pass2)
                        Return 0
                    Else

                        Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + vbNewLine
                        keywordpresent = 1
                    End If
                ElseIf Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(3).Value = "1" Then    'if arg no is 1
                    If words.Length <> (startindex + 2) Then
                        errorfunction("There should be only 1 argument.", lineerror_pass2)
                        Return 0

                    Else
                        If Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "num" Then  'if arg is num
                            Dim arg1 As String = words.ElementAt(startindex + 1).ToString
                            Dim arg1num As String
                            'check if hex or dec
                            If arg1(arg1.Length - 1) = "h" Then
                                arg1num = arg1.Substring(0, arg1.Length - 1)
                                Dim dec As Integer
                                Try
                                    dec = CLng("&H" & arg1num)

                                    If Not (dec >= 0 And dec <= 255) Then
                                        errorfunction("The hex number as argument1 must be between 0 to FF.", lineerror_pass2)
                                        Return 0

                                    End If
                                    If Asc(arg1.ToUpper.ElementAt(0)) >= 65 And Asc(arg1.ToUpper.ElementAt(0)) <= 70 Then
                                        arg1 = "0" + arg1
                                    End If
                                    Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + arg1 + vbNewLine
                                    keywordpresent = 1
                                Catch ex As Exception
                                    errorfunction("There should be a proper number as argument1.", lineerror_pass2)
                                    Return 0
                                End Try

                            Else
                                arg1num = arg1

                                Try
                                    Dim dec As Integer
                                    dec = Int(arg1num)

                                    If Not (dec >= 0 And dec <= 255) Then
                                        errorfunction("The decimal number as argument2 must be between 0 to 255.", lineerror_pass2)
                                        Return 0

                                    End If

                                    Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + vbNewLine
                                    keywordpresent = 1
                                Catch ex As Exception
                                    errorfunction("There should be a number as argument1.", lineerror_pass2)
                                    Return 0

                                End Try
                            End If

                        ElseIf Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "reg" Then      'if arg is reg
                            If words.ElementAt(startindex + 1).ToString.ToUpper() <> "A" And words.ElementAt(startindex + 1).ToString.ToUpper() <> "H" And words.ElementAt(startindex + 1).ToString.ToUpper() <> "L" Then
                                errorfunction("Give valid register as argument1.", lineerror_pass2)
                                Return 0
                            Else
                                Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + vbNewLine
                                keywordpresent = 1
                            End If

                        ElseIf Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "lab" Then  'if arg is label
                            Dim rowno1 As Integer = 0
                            Dim flag1 As Integer = 0
                            'check if label is present or not
                            While rowno1 < Main_Form.label_addr_Datagridview.RowCount
                                If words.ElementAt(startindex + 1).ToString = Main_Form.label_addr_Datagridview.Rows(rowno1).Cells(0).Value Then
                                    flag1 = 1
                                    Exit While

                                End If
                                rowno1 += 1
                            End While
                            If flag1 = 1 Then
                                Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + vbNewLine
                                keywordpresent = 1
                            Else
                                errorfunction("Give valid variable as argument1.", lineerror_pass2)
                                Return 0
                            End If

                        Else

                            If words.ElementAt(startindex + 1).ToString.ElementAt(0) = "%" Then

                                flag = 0
                                Dim rowno1 As Integer = 0
                                Dim flag1 As Integer = 0
                                'if the extern variable is present or not
                                While rowno1 < Main_Form.extern_Datagridview.RowCount
                                    If words.ElementAt(startindex + 1).ToString = Main_Form.extern_Datagridview.Rows(rowno1).Cells(0).Value Then
                                        flag = 1
                                        Exit While

                                    End If
                                    rowno1 += 1
                                End While
                                If flag = 1 Then

                                    Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + vbNewLine
                                    keywordpresent = 1

                                Else
                                    errorfunction("Give valid variable(may be extern) as argument1", lineerror_pass2)
                                    Return 0
                                End If

                            Else
                                'if arg is variable
                                Dim rowno1 As Integer = 0
                                Dim flag1 As Integer = 0
                                'check if variable is present in var_addr_val_Datagridview table or not
                                While rowno1 < Main_Form.var_addr_val_Datagridview.RowCount
                                    If words.ElementAt(startindex + 1).ToString = Main_Form.var_addr_val_Datagridview.Rows(rowno1).Cells(0).Value Then
                                        flag1 = 1
                                        Exit While

                                    End If
                                    rowno1 += 1
                                End While
                                If flag1 = 1 Then
                                    Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + vbNewLine
                                    keywordpresent = 1
                                Else
                                    errorfunction("Give valid variable as argument1.", lineerror_pass2)
                                    Return 0
                                End If
                            End If
                        End If




                    End If

                ElseIf Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(3).Value = "2" Then
                    Dim hexstart As String

                    If words.Length <> (startindex + 3) Then
                        errorfunction("There should be only 2 arguments.", lineerror_pass2)
                        Return 0
                    Else
                        If Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "num" Then
                            Dim arg1 As String = words.ElementAt(startindex + 1).ToString
                            Dim arg1num As String

                            If arg1(arg1.Length - 1) = "h" Then
                                arg1num = arg1.Substring(0, arg1.Length - 1)
                                Dim dec As Integer
                                Try
                                    dec = CLng("&H" & arg1num)


                                    If Not (dec >= 0 And dec <= 255) Then
                                        errorfunction("The hex number as argument1 must be between 0 to FF.", lineerror_pass2)
                                        Return 0

                                    End If

                                    If Asc(arg1.ToUpper.ElementAt(0)) >= 65 And Asc(arg1.ToUpper.ElementAt(0)) <= 70 Then
                                        arg1 = "0" + arg1

                                    End If
                                    hexstart = arg1
                                Catch ex As Exception
                                    errorfunction("There should be a proper number as argument1.", lineerror_pass2)
                                    Return 0
                                End Try

                            Else
                                arg1num = arg1

                                Try
                                    Dim dec As Integer
                                    dec = Int(arg1num)

                                    If Not (dec >= 0 And dec <= 255) Then
                                        errorfunction("The decimal number as argument1 must be between 0 to 255.", lineerror_pass2)
                                        Return 0

                                    End If
                                    'Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex) + " , " + words.ElementAt(startindex + 1)
                                Catch ex As Exception
                                    errorfunction("There should be a number as argument1.", lineerror_pass2)
                                    Return 0
                                End Try
                            End If
                        ElseIf Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "reg" Then
                            If words.ElementAt(startindex + 1).ToString.ToUpper() <> "A" And words.ElementAt(startindex + 1).ToString.ToUpper() <> "H" And words.ElementAt(startindex + 1).ToString.ToUpper() <> "L" Then
                                errorfunction("Give valid register as argument1.", lineerror_pass2)
                                Return 0
                            Else
                                ' Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex) + " , " + words.ElementAt(startindex + 1)
                            End If
                        Else

                            If words.ElementAt(startindex + 1).ToString.ElementAt(0) = "%" Then

                                flag = 0
                                Dim rowno1 As Integer = 0
                                Dim flag1 As Integer = 0
                                'if the extern variable is present or not
                                While rowno1 < Main_Form.extern_Datagridview.RowCount
                                    If words.ElementAt(startindex + 1).ToString = Main_Form.extern_Datagridview.Rows(rowno1).Cells(0).Value Then
                                        flag = 1
                                        Exit While

                                    End If
                                    rowno1 += 1
                                End While
                                If flag = 1 Then

                                    'Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + vbnewline
                                    ' keywordpresent = 1

                                Else
                                    errorfunction("Give valid variable(may be extern) as argument1", lineerror_pass2)
                                    Return 0
                                End If
                            Else
                                Dim rowno1 As Integer = 0
                                Dim flag1 As Integer = 0
                                While rowno < Main_Form.var_addr_val_Datagridview.RowCount
                                    If words.ElementAt(startindex + 1).ToString = Main_Form.var_addr_val_Datagridview.Rows(rowno).Cells(0).Value Then
                                        flag = 1
                                        Exit While

                                    End If
                                End While
                                If flag = 1 Then
                                    'Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex) + " , " + words.ElementAt(startindex + 1)
                                Else
                                    errorfunction("Give valid variable as argumeent1.", lineerror_pass2)
                                    Return 0
                                End If
                            End If


                        End If

                        If Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(5).Value = "num" Then
                            Dim arg1 As String = words.ElementAt(startindex + 2).ToString
                            Dim arg1num As String

                            If arg1(arg1.Length - 1) = "h" Then
                                arg1num = arg1.Substring(0, arg1.Length - 1)
                                Dim dec As Integer
                                ' Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + " , " + words.ElementAt(startindex + 2) + vbnewline
                                ' keywordpresent = 1

                                Try
                                    dec = CLng("&H" & arg1num)

                                    If Not (dec >= 0 And dec <= 255) Then
                                        errorfunction("The hex number as argument2 must be between 0 to FF.", lineerror_pass2)
                                        Return 0

                                    End If

                                    If Asc(arg1.ToUpper.ElementAt(0)) >= 65 And Asc(arg1.ToUpper.ElementAt(0)) <= 70 Then
                                        arg1 = "0" + arg1
                                    End If
                                    'checking 
                                    If words.ElementAt(startindex).ToString.ToUpper() = "MVIR" Then
                                        'if 1st arg is num then use hexstart as 1st arg 
                                        If Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "num" Then
                                            Main_Form.Corr8085_RichTxt.Text += "MVI" + " " + hexstart + " , " + arg1 + vbNewLine
                                            keywordpresent = 1
                                        Else
                                            Main_Form.Corr8085_RichTxt.Text += "MVI" + " " + words.ElementAt(startindex + 1) + " , " + arg1 + vbNewLine
                                            keywordpresent = 1
                                        End If

                                    Else

                                        If Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "num" Then
                                            'if 1st arg is num then use hexstart as 1st arg 
                                            Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + hexstart + " , " + arg1 + vbNewLine
                                            keywordpresent = 1
                                        Else
                                            Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + " , " + arg1 + vbNewLine
                                            keywordpresent = 1
                                        End If
                                        'Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + hexstart + " , " + arg1 + vbnewline
                                        'keywordpresent = 1
                                    End If
                                Catch ex As Exception
                                    errorfunction("There should be a proper number as argument2.", lineerror_pass2)
                                    Return 0
                                End Try
                            Else
                                arg1num = arg1

                                Try
                                    Dim dec As Integer
                                    dec = Int(arg1num)

                                    If Not (dec >= 0 And dec <= 255) Then
                                        errorfunction("The decimal number as argument2 must be between 0 to 255.", lineerror_pass2)
                                        Return 0

                                    End If
                                    If words.ElementAt(startindex).ToString.ToUpper() = "MVIR" Then
                                        Main_Form.Corr8085_RichTxt.Text += "MVI" + " " + words.ElementAt(startindex + 1) + " , " + words.ElementAt(startindex + 2) + vbNewLine
                                        keywordpresent = 1
                                    Else
                                        Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + " , " + words.ElementAt(startindex + 2) + vbNewLine
                                        keywordpresent = 1
                                    End If


                                Catch ex As Exception
                                    errorfunction("There should be a number as argument2.", lineerror_pass2)
                                    Return 0
                                End Try
                            End If
                        ElseIf Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(5).Value = "reg" Then
                            If words.ElementAt(startindex + 2).ToString.ToUpper() <> "A" And words.ElementAt(startindex + 2).ToString.ToUpper() <> "H" And words.ElementAt(startindex + 2).ToString.ToUpper() <> "L" Then
                                errorfunction("Give valid register as argument2.", lineerror_pass2)
                                Return 0
                            Else

                                If Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "num" Then
                                    Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + hexstart + " , " + words.ElementAt(startindex + 2) + vbNewLine
                                    keywordpresent = 1
                                Else
                                    Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + " , " + words.ElementAt(startindex + 2) + vbNewLine
                                    keywordpresent = 1
                                End If



                            End If
                        Else

                            If words.ElementAt(startindex + 2).ToString.ElementAt(0) = "%" Then

                                flag = 0
                                Dim rowno1 As Integer = 0
                                Dim flag1 As Integer = 0
                                'if the extern variable is present or not
                                While rowno1 < Main_Form.extern_Datagridview.RowCount
                                    If words.ElementAt(startindex + 2).ToString = Main_Form.extern_Datagridview.Rows(rowno1).Cells(0).Value Then
                                        flag = 1
                                        Exit While

                                    End If
                                    rowno1 += 1
                                End While
                                If flag = 1 Then

                                    If Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "num" Then
                                        Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + hexstart + " , " + words.ElementAt(startindex + 2) + vbNewLine
                                        keywordpresent = 1
                                    Else
                                        Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + " , " + words.ElementAt(startindex + 2) + vbNewLine
                                        keywordpresent = 1
                                    End If

                                Else
                                    errorfunction("Give valid variable(may be extern) as argument2.", lineerror_pass2)
                                    Return 0
                                End If
                            Else



                                'if 2nd arg is normal variable
                                Dim rowno1 As Integer = 0
                                Dim flag1 As Integer = 0
                                While rowno < Main_Form.var_addr_val_Datagridview.RowCount
                                    If words.ElementAt(startindex + 2).ToString = Main_Form.var_addr_val_Datagridview.Rows(rowno).Cells(0).Value Then
                                        flag = 1
                                        Exit While

                                    End If
                                End While
                                If flag = 1 Then
                                    If Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(4).Value = "num" Then
                                        Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + hexstart + " , " + words.ElementAt(startindex + 2) + vbNewLine
                                        keywordpresent = 1
                                    Else
                                        Main_Form.Corr8085_RichTxt.Text += words.ElementAt(startindex).ToString.ToUpper() + " " + words.ElementAt(startindex + 1) + " , " + words.ElementAt(startindex + 2) + vbNewLine
                                        keywordpresent = 1
                                    End If
                                Else
                                    errorfunction("Give valid variable as argument2.", lineerror_pass2)
                                    Return 0
                                End If
                            End If
                        End If
                    End If
                    Exit While
                End If
            End If
            rowno += 1

        End While
        If keywordpresent = 0 Then  'keyword is not correct
            errorfunction("Keyword is not correct.", lineerror_pass2)
            Return 0
        Else
            Return 1
        End If
        Return 0
    End Function

    '--------------------------------------------------

    '-------------------------------------------------
    'wordcheck function  return word type in pass1 used
    '------------------------------------------------

    Public Shared Function wordCheck(ByVal word, ByVal lineerror) As Integer
        Dim firstchar As Char
        Dim lastchar As Char
        firstchar = word(0)
        lastchar = word(word.Length - 1)
        If firstchar = "$" Then     'if 1st char is $
            If lastchar = ":" Then  'if last char is then : the error
                Main_Form.Error_RichTxt.Text += "Line No " & lineerror & ": " + word + " cannot be resolved as variable or label." + vbNewLine
                Main_Form.Corr8085_RichTxt.Text = ""      '8085 code ready box clear
                Return -1     '-1 for error

            Else
                Return 1        'for variable
            End If
        ElseIf lastchar = ":" Then     'if 1st char is $
            Return 2            'for label
        Else
            Dim rowno As Integer = 0
            Dim flag As Integer = 0
            ' for checking if correct keyword
            While rowno < 23
                If word.ToUpper() = Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(0).Value Then


                    'Main_Form.Corr8085_RichTxt.Text += Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(1).Value

                    ' Main_Form.Corr8085_RichTxt.Text += " "
                    Return 3            'for keyword
                    Exit While
                End If
                rowno += 1
            End While
            Return 4        'normal return
        End If




    End Function

    '-------------------------------------------------
    'reserved function  checks if some reserved keyword is used
    '------------------------------------------------
    Public Shared Function reservedwords(ByVal word, ByVal lineerror) As Integer
        word = word.ToString.ToUpper
        If word = "HLT" Or word = "ADDM" Or word = "NOP" Or word = "NULL" Or word = "MVI" Or word = "%" Or word = "$" Or word = "b" Or word = "B" Or word = "C" Or word = "D" Or word = "c" Or word = "d" Or word = "e" Or word = "E" Then
            errorfunction(word + " is a reserved keyword.It cannot be used.", lineerror)
            Return -1
        End If
        Return 0
    End Function

End Class
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

'MACRO CLASS
Public Class macro_codes           'macro_codes class declared-> this class will have macro name, macro code, macro argument no. macros argument values as attributes->finally for keeping record of each macro, an object of macro class is created and inserted in the arraylist "macros" after the attribues are being set during object creation

    Private num As Integer      'indicates the macro number

    Private macro As String     'macro name

    Private args As Integer     'number of arguments of the macros

    Private arg1 As String      'argument1
    Private arg2 As String      'argument2
    Private arg3 As String      'argument3

    Private macroCode As String     'macro Code 

    'Public Sub New(ByVal index As Integer, ByVal macName As String, ByVal numArg As Integer, ByVal Argu1 As String, ByVal Argu2 As String, ByVal Argu3 As String, ByVal source As String)

    ' num = index

    ' macro = macName

    '    args = numArg

    ' arg1 = Argu1
    ' arg2 = Argu2
    ' arg3 = Argu3

    '        macroCode = source

    ' End Sub

    'Public Function numGS(ByVal gors) As Integer

    'If gors = -1 Then

    '       Return (0)
    'End Function


    Public Property getNum() As Integer     'getNum is a function which when called will set the value of a macro_codes classes' objects' num attribute

        Get
            Return (num)                    'if get function is called simply return the objects num
        End Get

        Set(ByVal value As Integer)

            num = value                     'set the value of num appropriately if called
        End Set

    End Property

    Public Property getArgs() As Integer     'getArgs is a function which when called will set the value of a macro_codes classes' objects' args attribute


        Get
            Return (args)                    'if get function is called simply return the objects args
        End Get
        Set(ByVal value As Integer)

            args = value                     'set the value of args appropriately if called
        End Set
    End Property


    Public Property getArg1() As String     'getArg1 is a function which when called will set the value of a macro_codes classes' objects' arg1 attribute

        Get
            Return (arg1)                    'if get function is called simply return the objects arg1(argument 1)
        End Get
        Set(ByVal value As String)
            arg1 = value                     'set the value of arg1 appropriately if called
        End Set


    End Property


    Public Property getArg2() As String     'getArg2 is a function which when called will set the value of a macro_codes classes' objects'arg2 attribute

        Get
            Return (arg2)                    'if get function is called simply return the objects arg2(argument 2)
        End Get
        Set(ByVal value As String)
            arg2 = value                     'set the value ofarg2 appropriately if called
        End Set


    End Property

    Public Property getArg3() As String     'getArgs3 is a function which when called will set the value of a macro_codes classes' objects' arg3 attribute

        Get
            Return (arg3)                    'if get function is called simply return the objects arg3(argument 3)
        End Get
        Set(ByVal value As String)
            arg3 = value                     'set the value of arg3 appropriately if called
        End Set


    End Property




    Public Property getMacro() As String     'getMacro is a function which when called will set the value of a macro_codes classes' objects'  macro attribute

        Get

            Return (macro)                    'if get function is called simply return the objects macro(name)

        End Get

        Set(ByVal value As String)

            macro = value                     'set the value of macro (name)  appropriately if called

        End Set

    End Property

    Public Property getCode() As String     'getCode is a function which when called will set the value of a macro_codes classes' objects' macCode attribute
        Get
            Return (macroCode)                    'if get function is called simply return the objects macrCode
        End Get
        Set(ByVal value As String)

            macroCode = value                     'set the value of macroCode appropriately if called
        End Set


    End Property

End Class

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
'Assemble function class and
'assemble contents class

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

Public Class assemble_functions



    'Assembler pass1
    '-------------------------------
    'function to take out labels and
    'to get their corresponding addresses.
    Public Shared Function assemble_pass1()
        Dim location_counter As Integer = 0
        'take in mainRichtxt text as a string
        'string name wholecode contains whole 8085 code as string from mainRichtxt
        Dim wholecode As String = Main_Form.AssembledCode_RichTxt.Text

        'split whole code by newline
        Dim lines As String() = Regex.Split(wholecode, "\n")
        Dim each_line As String
        For Each each_line In lines
            'split lines by words

            Dim words As String() = Regex.Split(each_line, " ") 'words is the list of words in a line
            Dim first_word As String = words.ElementAt(0)       'check first word in the list word
            'check all first words.
            If first_word = "" Then
                Continue For

            End If
            If first_word(0) = ";" Then
                Continue For
                'if this was a comment then skip

            End If
            'if first word last character is :
            'add label name in label_info_DataGridView datagridview
            'then increase location_counter by 1
            If first_word(first_word.Length - 1) = ":" Then
                Main_Form.label_info_DataGridView.Rows.Add(New String() {first_word.Substring(0, first_word.Length - 1), location_counter})
                location_counter += 1
            Else
                Dim rowno As Integer = 0
                'else if not label then and comment then check for the
                'memonic memory requirement value
                'increment location_counter by the memory requirement value
                While rowno < 23
                    If first_word.ToUpper = Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(0).Value Then
                        location_counter += Main_Form.Mnemonic_DataGridView.Rows(rowno).Cells(2).Value
                    End If
                    rowno += 1
                End While


            End If

        Next

        If control_flow_signals.asmbling_sec_file = 0 Then

            assembled_contents.Location_counter_value = location_counter

        End If




        Return 0
    End Function

    'Assembler pass1
    '-------------------------------
    'function to replace the labels by address
    Public Shared Function assemble_pass2()
        'split wholecode by \n
        Dim wholecode As String = Main_Form.AssembledCode_RichTxt.Text
        Dim lines As String() = Regex.Split(wholecode, "\n")
        'if comment i.e first character ; then skip
        Dim each_line As String
        For Each each_line In lines
            If each_line = "" Then
                Continue For

            End If
            If each_line.ElementAt(0) = ";" Then
                Continue For
            End If
            'split each_line by space
            'store words in list named words
            Dim words As String() = Regex.Split(each_line, " ")
            Dim each_word As String
            Dim word As String
            'check each word in words 
            'if label then continue
            Dim wordindex As Integer = 0
            Dim ascii As Integer = 0
            For Each word In words
                each_word = ""
                wordindex = 0
                While wordindex < word.Length
                    ascii = Asc(word(wordindex))

                    If Asc(word(wordindex)) <> 13 And word(wordindex) <> " " Then
                        each_word += word(wordindex)
                    Else

                        Exit While

                    End If
                    wordindex += 1
                End While







                If each_word(each_word.Length - 1) = ":" Then
                    Continue For

                Else
                    'if not type label: then check in label_info_DataGridView table
                    'put the address of label from the table
                    Dim rowno As Integer = 0
                    Dim flag As Integer = 0
                    Dim check As String
                    While rowno < Main_Form.label_info_DataGridView.RowCount
                        check = Main_Form.label_info_DataGridView.Rows(rowno).Cells(0).Value
                        If each_word = check Then
                            Main_Form.Linked_Loaded_comp_RichTxt.Text += "~" + Main_Form.label_info_DataGridView.Rows(rowno).Cells(1).Value + " "
                            flag = 1 'if a variable then flag is 1
                            Exit While

                        End If
                        rowno += 1
                    End While
                    If flag = 0 Then
                        'if flag is 0 then it is a memonic so print as it is.
                        Main_Form.Linked_Loaded_comp_RichTxt.Text += each_word + " "

                    End If

                End If

            Next
            Main_Form.Linked_Loaded_comp_RichTxt.Text += vbNewLine

        Next
        Return 0
    End Function

    '-------------------------------------------


End Class

'-----------------------------------------------------------------------------------------------

'assemble contents contain variable to store the contents of the first file that got assembled
Public Class assembled_contents

    'contains the assemblesd code in richtextbox named Linked_Loaded_comp_RichTxt of original file.
    Public Shared assembled_code1 As String
    Public Shared Location_counter_value As Integer = 0



End Class
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
'Loading functions
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Public Class load_functions

    'Loading code2 pass1 for getting new addresses for the extern variables
    'for the 2nd code
    Public Shared Function loadcode2_pass1()
        Dim rowno As Integer = 0
        While rowno < Main_Form.label_info_DataGridView.Rows.Count - 1



            Main_Form.label_info_DataGridView.Rows(rowno).Cells(1).Value = (CInt(Main_Form.label_info_DataGridView.Rows(rowno).Cells(1).Value) + CInt(Main_Form.Code2_Addr_Txt.Text))

            rowno += 1
        End While

        Dim strcode2 As String = Main_Form.assembled_RichTxt2.Text

        Dim lines As String() = Regex.Split(strcode2, "\n")
        Dim line As String


        For Each line In lines
            Dim words As String() = Regex.Split(line, " ") 'words is the list of words in a line
            Dim word As String
            For Each word In words
                'MessageBox.Show(word)
                If word = "" Then
                    Continue For

                End If
                'check if the word has ~ this would mean that 
                'the word is addtress
                If word.ElementAt(0) = "~" Then

                    Main_Form.Linked_LoadedRichTxt2.Text += Convert.ToString(CInt(word.Substring(1, word.Length - 1)) + CInt(Main_Form.Code2_Addr_Txt.Text)) + " "

                Else
                    'if not a address print as it is
                    Main_Form.Linked_LoadedRichTxt2.Text += word + " "


                End If



            Next

            'add nedwline
            Main_Form.Linked_LoadedRichTxt2.Text += vbNewLine
        Next


        Return 0
    End Function

    'loading code1 pass1 replacing original file extern vaiables
    Public Shared Function loadcode1_pass1() As Integer


        Dim assembled_code1 As String = Main_Form.assembled_RichTxt.Text
        Dim lines As String() = Regex.Split(assembled_code1, "\n")
        Dim line As String
        For Each line In lines
            Dim words As String() = Regex.Split(line, " ") 'words is the list of words in a line
            Dim word As String
            For Each word In words

                If word = "" Then
                    Continue For
                End If
                If word.ElementAt(0) = "%" Then
                    Dim extern_var As String = word.Substring(1, word.Length - 1)
                    Dim rowno As Integer = 0
                    Dim flag = 0
                    While rowno < Main_Form.label_info_DataGridView.Rows.Count

                        If extern_var = Main_Form.label_info_DataGridView.Rows(rowno).Cells(0).Value Then
                            Dim new_address As String
                            new_address = Main_Form.label_info_DataGridView.Rows(rowno).Cells(1).Value
                            'MessageBox.Show(new_address)
                            Main_Form.Linked_LoadedRichTxt.Text += new_address + " "
                            flag = 1
                            Exit While



                        End If
                        rowno += 1
                    End While

                    If flag = 0 Then

                        Main_Form.LinkingError_RichTxt.Text = "Linking error variable " + extern_var + " not found "
                        Return (-1)

                    End If
                ElseIf word.ElementAt(0) = "~" Then
                    Main_Form.Linked_LoadedRichTxt.Text += Convert.ToString(CInt(word.Substring(1, word.Length - 1)) + CInt(Main_Form.Code1add_Txt.Text)) + " "

                Else

                    Main_Form.Linked_LoadedRichTxt.Text += word + " "

                End If




            Next
            Main_Form.Linked_LoadedRichTxt.Text += vbNewLine


        Next






        Return 0
    End Function



End Class


'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX THE END XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX