Imports System
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports Microsoft.VisualBasic
Public Class AddMacroForm
    'Line numbers on side of textboxe1(main editor) using pictureboxes
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub DrawRichTextBoxLineNumbers(ByRef g As Graphics)
        'Calculate font heigth as the difference in Y coordinate 
        'between line 2 and line 1
        'Note that the RichTextBox text must have at least two lines. 
        '  So the initial Text property of the RichTextBox 
        '  should not be an empty string. It could be something 
        '  like vbcrlf & vbcrlf & vbcrlf 
        With code
            Dim font_height As Single

            font_height = code.Font.GetHeight()


            'Get the first line index and location
            Dim first_index As Integer
            Dim first_line As Integer
            Dim first_line_y As Integer
            first_index = .GetCharIndexFromPosition(New  _
                  Point(0, g.VisibleClipBounds.Y + font_height / 3))
            first_line = .GetLineFromCharIndex(first_index)
            first_line_y = .GetPositionFromCharIndex(first_index).Y

            'Print on the PictureBox the visible line numbers of the RichTextBox
            g.Clear(Control.DefaultBackColor)
            Dim i As Integer = first_line
            Dim y As Single
            Do While y < g.VisibleClipBounds.Y + g.VisibleClipBounds.Height
                y = first_line_y + 2 + font_height * (i - first_line - 1)
                g.DrawString((i).ToString, .Font, Brushes.DarkBlue, PictureBox1.Width _
                      - g.MeasureString((i).ToString, .Font).Width, y)
                i += 1
            Loop
            'Debug.WriteLine("Finished: " & firstLine + 1 & " " & i - 1)
        End With
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim res1 As Integer = frMac.isValid()       'checks the validity of macro declared in the sense trivial checking(name of macro, arguments etc.)
        ' Dim res2 As Integer = frMac.syntax()


        If res1 < 0 Then

            'MessageBox.Show("Error Code :" + Convert.ToString(res1 * 10))
            ' Exit Sub
        Else


            If Not ((parc1.Text = "C1" Or parc1.Text = "R1" Or parc1.Text = "M1") And (parc2.Text = "C2" Or parc2.Text = "M2" Or parc2.Text = "R2" Or parc2.Text = "") And (parc3.Text = "C3" Or parc3.Text = "M3" Or parc3.Text = "R3" Or parc3.Text = "")) Then
                'i.e. User attempted to change the default argument types(R1,M1,C1 etc.)
                MessageBox.Show("Invalid Argument Types")

                '                code.Text = ""     'User need not define the code again
                parc1.Text = ""             'Reset the faulty values 
                parc1.SelectedText = ""

                parc2.Text = ""
                parc2.SelectedText = ""
                parc3.Text = ""
                parc3.SelectedText = ""
                '               macName.Text = ""   'User though need not define the macro code and name again


                Exit Sub
            Else



            End If


            If parc3.Text <> "" Then        'If parameter 3 is not NULL and we are in the else part -> parc2.Text is not NULL as well -> no. of args = 3
                res1 = 3

            Else
                If parc2.Text <> "" Then        'Similarly No. of args in this case is 2
                    res1 = 2
                Else
                    res1 = 1                    'Else 1
                End If

            End If


            ' Dim newMac As New macro_codes(globalVars.macros.ToArray.Length, macName.Text, res1, parc1.Text, parc2.Text, parc3.Text, code.Text)

            'Dim newMac As New macro_codes With {.index = globalVars.macros.ToArray.Length, .macName = macName.Text, .numArg = res1, .arg1 = parc1.Text, .arg2 = parc2.Text, .arg3 = parc3.Text}
            frMac.macropass0()              'Pass0 ensures no empty vacuous spaces (removes them if at all they are present)


            Dim lines As String() = Regex.Split(code.Text, "\n")        'Split the line on the basis 

            code.Text = ""              'initialze the code again to empty string


            Dim words As String()       ' stores the collection of words

            Dim word As String          'stores the present word

            For Each line In lines

                words = Regex.Split(line, " ")      'split the words on the basis of space(" ")

                For Each word In words

                    word = word.ToUpper()               'convert word to upper case
                    code.Text = code.Text + word + " "      'write the word on the code field
                    'separate the written words by space
                Next
                code.Text += vbNewLine          'add a new line after all the words of a line have been written to the code field


            Next

            If (Main_Form.Macro_ComboBox.FindStringExact(macName.Text) >= 0) Then        'if a macro with same macro name exists(found in the list box) report the error
                MessageBox.Show("A Macro With specified name already exists")
            Else




                Dim result = MessageBox.Show("Do you want to make any changes to the " + Me.macName.Text + " ?", "Confirm Addition", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.No Then


                    Dim newMac As New macro_codes()    'declare the new object

                    '            Dim t As New TestClass()

                    ' Get the type and PropertyInfo. 
                    Dim myType As Type = newMac.GetType()       'get the type of the object

                    Dim pinfo As PropertyInfo = newMac.GetType().GetProperty("getNum")      'get the argument number property
                    pinfo.SetValue(newMac, globalVars.macros.ToArray.Length, Nothing)       'set its' value

                    pinfo = newMac.GetType().GetProperty("getMacro")
                    pinfo.SetValue(newMac, macName.Text, Nothing)   'set the name of the macro

                    pinfo = newMac.GetType().GetProperty("getArgs")
                    pinfo.SetValue(newMac, res1, Nothing)       'set the no. of args

                    pinfo = newMac.GetType().GetProperty("getArg1")
                    pinfo.SetValue(newMac, parc1.Text, Nothing) 'set the argument 1

                    pinfo = newMac.GetType().GetProperty("getArg2")
                    pinfo.SetValue(newMac, parc2.Text, Nothing) 'argument2

                    pinfo = newMac.GetType().GetProperty("getArg3")
                    pinfo.SetValue(newMac, parc3.Text, Nothing)     'argument3

                    pinfo = newMac.GetType().GetProperty("getCode")
                    pinfo.SetValue(newMac, code.Text, Nothing)      'set the code

                    Main_Form.Macro_ComboBox.Items.Add(macName.Text)         'add the added macro to the combobox


                    globalVars.macros.Add(newMac)           'add the object to the arraylist

                    MessageBox.Show("Macro " + macName.Text + " has been successfully added.")  'display the succes mssg


                    code.Text = ""      'initialize the components for the nect addition
                    parc1.Text = ""
                    parc1.SelectedText = ""

                    parc2.Text = ""
                    parc2.SelectedText = ""
                    parc3.Text = ""
                    parc3.SelectedText = ""
                    macName.Text = ""

                    Me.Hide()       'hide the macro form and display the main form
                    Main_Form.Show()

                Else



                End If


            End If


        End If




    End Sub

    Private Sub cancel_b_Click(sender As System.Object, e As System.EventArgs) Handles cancel_b.Click
        code.Text = ""              'prepare the AddMacroForm form for the next call 
        parc1.Text = ""
        parc1.SelectedText = ""
        'setting all the text values to ""
        parc2.Text = ""
        parc2.SelectedText = ""
        parc3.Text = ""
        parc3.SelectedText = ""
        macName.Text = ""

        'enabling the components
        Me.macName.Enabled = True
        Me.parc1.Enabled = True
        Me.parc2.Enabled = True
        Me.parc3.Enabled = True
        Me.code.Enabled = True
        Me.Button1.Enabled = True
        Me.Button1.Visible = True


        Me.Hide()
        Main_Form.Show()
        'hide the macro form and display the main form(Main_Form)

    End Sub

    Private Sub code_VScroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles code.VScroll
        PictureBox1.Invalidate()

    End Sub

    Private Sub code_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles code.Resize
        PictureBox1.Invalidate()
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        DrawRichTextBoxLineNumbers(e.Graphics)
    End Sub
End Class
Public Class frMac

    Public Shared Function macropass0() As Integer
        Dim str As String = AddMacroForm.code.Text

        AddMacroForm.code.Text = ""        'clear richtextbox1
        ' Split string based on spaces
        Dim lines As String() = Regex.Split(str, "\n")  'splits the lines of code
        Dim line As String          'stores a particular line
        Dim lineflag As Integer = 0     'used for line end flag
        Dim spaceflag As Integer = 0    'used as space detected flag
        For Each line In lines
            Dim words As String() = Regex.Split(line, " ")  'spilt words on basis of spaces
            Dim word As String
            spaceflag = 0       'set default value of space flag
            For Each word In words

                If word <> "" And spaceflag = 0 And lineflag = 0 Then   'if none of the space flag and line flag is 1 simply append the word

                    AddMacroForm.code.Text += word
                    spaceflag = 1       'set the flags
                    lineflag = 1

                ElseIf word <> "" And spaceflag = 0 And lineflag = 1 Then
                    AddMacroForm.code.Text += vbNewLine 'if line flag is 1 then give new line
                    AddMacroForm.code.Text += word      'append the word
                    spaceflag = 1               'set the space flag

                ElseIf word <> "" And spaceflag = 1 And lineflag = 1 Then
                    AddMacroForm.code.Text += " " + word    'else simply append the word

                End If


            Next



        Next

        Return 0
    End Function

    Public Shared Function isValid() As Integer

        If AddMacroForm.macName.Text.Length = 0 Then

            MessageBox.Show("Macro Name cannot be NULL")            'Report error if macro name has not be provided
            Return (-1)
        Else

            If AddMacroForm.parc1.Text.Length = 0 Then
                MessageBox.Show("Argument1 cannot be NULL")     'Report error if none of the arguments have been provided
                Return (-2)
            Else

                If AddMacroForm.parc2.Text = "" AndAlso AddMacroForm.parc3.Text <> "" Then
                    MessageBox.Show("Argument2 cannot be NULL if Argument3 is not NULL ")   'Report error if arg3 is not null be arg2 is null
                    Return (-3)

                Else
                    Return (0)
                End If

            End If


        End If


        'Return (0)
    End Function

End Class