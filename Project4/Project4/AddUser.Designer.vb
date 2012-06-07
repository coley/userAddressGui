<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUser
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtZipCode = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lbl8 = New System.Windows.Forms.Label()
        Me.comboStates = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.lblErrorId = New System.Windows.Forms.Label()
        Me.lblErrorFirstName = New System.Windows.Forms.Label()
        Me.lblErrorLastName = New System.Windows.Forms.Label()
        Me.lblErrorEmail = New System.Windows.Forms.Label()
        Me.lblErrorPhone = New System.Windows.Forms.Label()
        Me.lblErrorCity = New System.Windows.Forms.Label()
        Me.lblErrorState = New System.Windows.Forms.Label()
        Me.lblErrorZipCode = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(286, 406)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 16
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(189, 406)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtZipCode
        '
        Me.txtZipCode.Location = New System.Drawing.Point(112, 356)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(114, 20)
        Me.txtZipCode.TabIndex = 15
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(112, 254)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(213, 20)
        Me.txtCity.TabIndex = 11
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(112, 206)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(114, 20)
        Me.txtPhone.TabIndex = 9
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(112, 162)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(213, 20)
        Me.txtEmail.TabIndex = 7
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(112, 113)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(213, 20)
        Me.txtLastName.TabIndex = 5
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(112, 67)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(213, 20)
        Me.txtFirstName.TabIndex = 3
        '
        'lbl8
        '
        Me.lbl8.AutoSize = True
        Me.lbl8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl8.Location = New System.Drawing.Point(14, 23)
        Me.lbl8.Name = "lbl8"
        Me.lbl8.Size = New System.Drawing.Size(20, 13)
        Me.lbl8.TabIndex = 0
        Me.lbl8.Text = "ID"
        '
        'comboStates
        '
        Me.comboStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboStates.FormattingEnabled = True
        Me.comboStates.Location = New System.Drawing.Point(112, 303)
        Me.comboStates.MaxDropDownItems = 50
        Me.comboStates.MaxLength = 2
        Me.comboStates.Name = "comboStates"
        Me.comboStates.Size = New System.Drawing.Size(46, 21)
        Me.comboStates.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 361)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Zip Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 311)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "State"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "City"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Phone"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Email"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Last Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "First Name"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(112, 21)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(67, 20)
        Me.txtId.TabIndex = 1
        '
        'lblErrorId
        '
        Me.lblErrorId.AutoSize = True
        Me.lblErrorId.ForeColor = System.Drawing.Color.Red
        Me.lblErrorId.Location = New System.Drawing.Point(112, 44)
        Me.lblErrorId.Name = "lblErrorId"
        Me.lblErrorId.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorId.TabIndex = 18
        '
        'lblErrorFirstName
        '
        Me.lblErrorFirstName.AutoSize = True
        Me.lblErrorFirstName.ForeColor = System.Drawing.Color.Red
        Me.lblErrorFirstName.Location = New System.Drawing.Point(112, 90)
        Me.lblErrorFirstName.Name = "lblErrorFirstName"
        Me.lblErrorFirstName.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorFirstName.TabIndex = 19
        '
        'lblErrorLastName
        '
        Me.lblErrorLastName.AutoSize = True
        Me.lblErrorLastName.ForeColor = System.Drawing.Color.Red
        Me.lblErrorLastName.Location = New System.Drawing.Point(112, 137)
        Me.lblErrorLastName.Name = "lblErrorLastName"
        Me.lblErrorLastName.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorLastName.TabIndex = 20
        '
        'lblErrorEmail
        '
        Me.lblErrorEmail.AutoSize = True
        Me.lblErrorEmail.ForeColor = System.Drawing.Color.Red
        Me.lblErrorEmail.Location = New System.Drawing.Point(112, 185)
        Me.lblErrorEmail.Name = "lblErrorEmail"
        Me.lblErrorEmail.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorEmail.TabIndex = 21
        '
        'lblErrorPhone
        '
        Me.lblErrorPhone.AutoSize = True
        Me.lblErrorPhone.ForeColor = System.Drawing.Color.Red
        Me.lblErrorPhone.Location = New System.Drawing.Point(112, 229)
        Me.lblErrorPhone.Name = "lblErrorPhone"
        Me.lblErrorPhone.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorPhone.TabIndex = 22
        '
        'lblErrorCity
        '
        Me.lblErrorCity.AutoSize = True
        Me.lblErrorCity.ForeColor = System.Drawing.Color.Red
        Me.lblErrorCity.Location = New System.Drawing.Point(113, 277)
        Me.lblErrorCity.Name = "lblErrorCity"
        Me.lblErrorCity.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorCity.TabIndex = 23
        '
        'lblErrorState
        '
        Me.lblErrorState.AutoSize = True
        Me.lblErrorState.ForeColor = System.Drawing.Color.Red
        Me.lblErrorState.Location = New System.Drawing.Point(113, 332)
        Me.lblErrorState.Name = "lblErrorState"
        Me.lblErrorState.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorState.TabIndex = 24
        '
        'lblErrorZipCode
        '
        Me.lblErrorZipCode.AutoSize = True
        Me.lblErrorZipCode.ForeColor = System.Drawing.Color.Red
        Me.lblErrorZipCode.Location = New System.Drawing.Point(113, 380)
        Me.lblErrorZipCode.Name = "lblErrorZipCode"
        Me.lblErrorZipCode.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorZipCode.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(237, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "( format: 111-222-3333 )"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(335, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "( format: myname@domain.com )"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(232, 361)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(156, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "( format: 12345 or 12345-1111 )"
        '
        'AddUser
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(519, 454)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblErrorZipCode)
        Me.Controls.Add(Me.lblErrorState)
        Me.Controls.Add(Me.lblErrorCity)
        Me.Controls.Add(Me.lblErrorPhone)
        Me.Controls.Add(Me.lblErrorEmail)
        Me.Controls.Add(Me.lblErrorLastName)
        Me.Controls.Add(Me.lblErrorFirstName)
        Me.Controls.Add(Me.lblErrorId)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtZipCode)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lbl8)
        Me.Controls.Add(Me.comboStates)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AddUser"
        Me.Text = "Add User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lbl8 As System.Windows.Forms.Label
    Friend WithEvents comboStates As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lblErrorId As System.Windows.Forms.Label
    Friend WithEvents lblErrorFirstName As System.Windows.Forms.Label
    Friend WithEvents lblErrorLastName As System.Windows.Forms.Label
    Friend WithEvents lblErrorEmail As System.Windows.Forms.Label
    Friend WithEvents lblErrorPhone As System.Windows.Forms.Label
    Friend WithEvents lblErrorCity As System.Windows.Forms.Label
    Friend WithEvents lblErrorState As System.Windows.Forms.Label
    Friend WithEvents lblErrorZipCode As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
