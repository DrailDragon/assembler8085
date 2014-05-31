Public Class builtin_macrosform

    
    Private Sub builtin_macrosform_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(480, 200)
        Cursor.Position = Me.PointToScreen(New Point(140, 55))

        'select tab
        'MVIR
        If ButtonFlowSignals.Which_Button_clicked = 1 Then
            Builtin_macros_tabcontrol.SelectedTab = MVIR_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If
        'MVIM
        If ButtonFlowSignals.Which_Button_clicked = 2 Then
            Builtin_macros_tabcontrol.SelectedTab = MVIM_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'LDA

        If ButtonFlowSignals.Which_Button_clicked = 3 Then
            Builtin_macros_tabcontrol.SelectedTab = LDA_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'LXI


        If ButtonFlowSignals.Which_Button_clicked = 4 Then
            Builtin_macros_tabcontrol.SelectedTab = LXI_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'STA

        If ButtonFlowSignals.Which_Button_clicked = 5 Then
            Builtin_macros_tabcontrol.SelectedTab = STA_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'SHLD

        If ButtonFlowSignals.Which_Button_clicked = 6 Then
            Builtin_macros_tabcontrol.SelectedTab = SHLD_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'ADD

        If ButtonFlowSignals.Which_Button_clicked = 7 Then
            Builtin_macros_tabcontrol.SelectedTab = ADD_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'ADI
        If ButtonFlowSignals.Which_Button_clicked = 8 Then
            Builtin_macros_tabcontrol.SelectedTab = ADI_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'ADDMM
        If ButtonFlowSignals.Which_Button_clicked = 9 Then
            Builtin_macros_tabcontrol.SelectedTab = ADDMM_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'JNZ
        If ButtonFlowSignals.Which_Button_clicked = 10 Then
            Builtin_macros_tabcontrol.SelectedTab = JNZ_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'JMP
        If ButtonFlowSignals.Which_Button_clicked = 11 Then
            Builtin_macros_tabcontrol.SelectedTab = JMP_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If
        'SBB
        If ButtonFlowSignals.Which_Button_clicked = 12 Then
            Builtin_macros_tabcontrol.SelectedTab = SBB_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'SBI
        If ButtonFlowSignals.Which_Button_clicked = 13 Then
            Builtin_macros_tabcontrol.SelectedTab = SBI_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If

        'ADC

        If ButtonFlowSignals.Which_Button_clicked = 14 Then
            Builtin_macros_tabcontrol.SelectedTab = ADC_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If
        'MOV
        If ButtonFlowSignals.Which_Button_clicked = 15 Then
            Builtin_macros_tabcontrol.SelectedTab = MOV_TabPage
            ButtonFlowSignals.Which_Button_clicked = 0
        End If






    End Sub
    'JMP
    Private Sub JMP_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles JMP_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "JMP " + JMP_txt.Text
        Me.Close()

    End Sub

    Private Sub JMP_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles JMP_Cancel_btn.Click
        Me.Close()
    End Sub
    'STA
    Private Sub STA_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles STA_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "STA " + STA_txt.Text

        Me.Close()
    End Sub

    Private Sub STA_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles STA_Cancel_btn.Click
        Me.Close()
    End Sub
    'SHLD
    Private Sub SHLD_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles SHLD_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "SHLD " + SHLD_txt.Text

        Me.Close()
    End Sub

    Private Sub SHLD_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles SHLD_Cancel_btn.Click
        Me.Close()
    End Sub
    'SBI
    Private Sub SBI_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles SBI_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "SBI " + SBI_txt.Text
        Me.Close()

    End Sub

    Private Sub SBI_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles SBI_Cancel_btn.Click
        Me.Close()
    End Sub
    'SBB
    Private Sub SBB_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles SBB_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "SBB " + SBB_ComboBox.Text
        Me.Close()
    End Sub

    Private Sub SBB_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles SBB_Cancel_btn.Click
        Me.Close()
    End Sub
    'MVIR
    Private Sub MVIR_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles MVIR_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "MVIR " + MVIR_ComboBox.Text

        Me.Close()


    End Sub

    Private Sub MVIR_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles MVIR_Cancel_btn.Click
        Me.Close()
        MVIR_Panel.Visible = False


    End Sub
    'MVIM
    Private Sub MVIM_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles MVIM_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "MVIM " + MVIM_Txt.Text

        Me.Close()
    End Sub

    Private Sub MVIM_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles MVIM_Cancel_btn.Click
        Me.Close()
    End Sub
    'MOV
    Private Sub MOV_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles MOV_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "MOV " + MOV_ComboBox1.Text + " " + MOV_ComboBox2.Text
        Me.Close()

    End Sub

    Private Sub MOV_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles MOV_Cancel_btn.Click
        Me.Close()
    End Sub
    'LXI
    Private Sub LXI_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles LXI_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "LXI h " + LXI_txt.Text

        Me.Close()
    End Sub

    Private Sub LXI_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles LXI_Cancel_btn.Click
        Me.Close()
    End Sub
    'LDA
    Private Sub LDA_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles LDA_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "LDA " + LDA_txt.Text

        Me.Close()

    End Sub

    Private Sub LDA_Canel_btn_Click(sender As System.Object, e As System.EventArgs) Handles LDA_Canel_btn.Click
        Me.Close()
    End Sub
    'JNZ
    Private Sub JNZ_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles JNZ_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "JNZ " + JNZ_txt.Text
        Me.Close()

    End Sub

    Private Sub JNZ_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles JNZ_Cancel_btn.Click
        Me.Close()
    End Sub
    'ADI
    Private Sub ADI_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADI_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "ADI " + ADI_txt.Text
        Me.Close()

    End Sub

    Private Sub ADI_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADI_Cancel_btn.Click
        Me.Close()
    End Sub
    'ADDMM
    Private Sub ADDMM_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADDMM_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "ADDMM " + ADDMM_txt3.Text + " " + ADDMM_txt2.Text + " " + ADDMM_txt1.Text
        Me.Close()

    End Sub

    Private Sub ADDMM_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADDMM_Cancel_btn.Click
        Me.Close()
    End Sub
    'ADD
    Private Sub ADD_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADD_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "ADD " + ADD_ComboBox.Text

        Me.Close()

    End Sub

    Private Sub ADD_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADD_Cancel_btn.Click
        Me.Close()
    End Sub
    'ADC
    Private Sub ADC_Done_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADC_Done_btn.Click
        Main_Form.mainRichTxt.SelectedText = "ADC " + ADC_ComboBox.Text
        Me.Close()
    End Sub

    Private Sub ADC_Cancel_btn_Click(sender As System.Object, e As System.EventArgs) Handles ADC_Cancel_btn.Click
        Me.Close()
    End Sub


End Class
Public Class ButtonFlowSignals
    Public Shared Which_Button_clicked = 0


End Class
