'***************************************************************************************************
'*
'*      Class:          UpdateUser         
'*      Author:         Nicole LaBonte
'*      Date Created:   December 17, 2011
'*      Description:    A form that updates an existing user.  This class has methods to validate the 
'*                      user data entered, provide feedback to the user on the data entered, 
'*                      update an existing user object, and update the user in the XML file.
'*                      
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

'Imports
Imports System.Text.RegularExpressions

Public Class UpdateUser

    'Declare constants
    Const minLengthFirstName As Integer = 1
    Const maxLengthFirstName As Integer = 25
    Const minLengthLastName As Integer = 2
    Const maxLengthLastName As Integer = 25
    Const minLengthEmail As Integer = 5
    Const maxLengthEmail As Integer = 30
    Const minLengthPhone As Integer = 10
    Const maxLengthPhone As Integer = 15
    Const minLengthCity As Integer = 2
    Const maxLengthCity As Integer = 25
    Const minLengthZipCode As Integer = 5
    Const maxLengthZipCode As Integer = 10

    'Create a public property for a User
    Public Property aUser As User

    '************************************************************************************************
    '*  Method is processed when the UpdateUser form is loaded.  This method calls other methods to 
    '*  populate the states in the state combobox, set the max length of the entry fields, 
    '*  clear any error labels, and populate the fields with the values of the currently selected user
    '************************************************************************************************
    Private Sub UpdateUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Populate state list
            populateStates()

        Catch ex As Exception

            MessageBox.Show("Error loading states. Exiting...")
            Me.Close()

        End Try

        'Set default values of fields
        populateFieldDefaultValues()

        'Update field attributes on form
        setFieldAttributes()

        'Clear errors
        clearErrors()

    End Sub


    '************************************************************************************************
    '*  Method populates the fields with the values of the currently selected user.  It also
    '*  calls a method to set the user's state in the state combobox.
    '************************************************************************************************
    Private Sub populateFieldDefaultValues()

        'Set fields for user
        lblId.Text = aUser.Id.ToString
        txtFirstName.Text = aUser.FirstName
        txtLastName.Text = aUser.LastName
        txtEmail.Text = aUser.Email
        txtPhone.Text = aUser.Phone
        txtCity.Text = aUser.City
        txtZipCode.Text = aUser.ZipCode

        'Select state in combo box
        setUserState()

    End Sub

    '************************************************************************************************
    '*  Method closes the UpdateUser form.
    '************************************************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    '************************************************************************************************
    '*  Method populates the states in the state combobox.  It calls a State method to initialize
    '*  and obtain all states from the XML file and then it loops through these states to populate
    '*  the states combobox.
    '************************************************************************************************
    Private Sub populateStates()
        'Clear state combobox
        comboStates.Items.Clear()

        'Initialize states
        State.initialize()

        'Add all states to combobox
        For Each usState As State In State.States
            comboStates.Items.Add(usState.Abbreviation)
        Next

    End Sub

    '************************************************************************************************
    '*  Method sets the user's state in the state combobox to the state corresponding to the state
    '*  in the user object.
    '************************************************************************************************
    Private Sub setUserState()
        'Declare variables
        Dim userStateIndex As Integer

        'Set default
        userStateIndex = -1

        'Loop through all states in states combobox to find matching state
        For index As Integer = 0 To comboStates.Items.Count - 1

            If aUser.State.ToUpper.Equals(comboStates.Items(index).ToString.ToUpper) Then
                userStateIndex = index
                Exit For
            End If
        Next

        'Set selected index based on matching state in states combobox
        comboStates.SelectedIndex = userStateIndex
    End Sub

    '************************************************************************************************
    '*  Method is processed when the update button is clicked on the UpdateUser form.  This method calls 
    '*  a method to clear the errors in the labels and update a user.  If the user is updated successfully,
    '*  this method will display a success message box and close the form.
    '************************************************************************************************
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        'Declare variables
        Dim isUserUpdated As Boolean = False

        'Clear error labels
        clearErrors()

        'Attempt to add user
        isUserUpdated = updateUser()

        'Verify if user was added
        If isUserUpdated Then
            MessageBox.Show("User has been updated.")
            Me.Close()
        End If

    End Sub

    '************************************************************************************************
    '*  Method attempts to update an existing user object and update the corresponding data in
    '*  the XML file. If the user is updated, then true is returned from the function.
    '************************************************************************************************
    Private Function updateUser() As Boolean
        'Declare variables
        Dim isUserUpdated As Boolean = False

        'If all fields are valid, then user is updated
        If validateUserFields() Then

            Try
                aUser.FirstName = validateFirstName()
                aUser.LastName = validateLastName()
                aUser.Email = validateEmail()
                aUser.Phone = validatePhone()
                aUser.City = validateCity()
                aUser.ZipCode = validateZipCode()
                aUser.State = validateState()

                User.updateUser(aUser)

                isUserUpdated = True

            Catch ex As Exception

                MessageBox.Show("Error updating user.")
                isUserUpdated = False

            End Try
        Else

            isUserUpdated = False

        End If

        'Return boolean indicating whether or not user was updated
        Return isUserUpdated

    End Function

    '************************************************************************************************
    '*  Method sets the max length of the entry fields.
    '************************************************************************************************
    Private Sub setFieldAttributes()

        'Set max lengths of all entry fields
        txtFirstName.MaxLength = maxLengthFirstName
        txtLastName.MaxLength = maxLengthLastName
        txtEmail.MaxLength = maxLengthEmail
        txtPhone.MaxLength = maxLengthPhone
        txtCity.MaxLength = maxLengthCity
        txtZipCode.MaxLength = maxLengthZipCode

    End Sub

    '************************************************************************************************
    '*  Method validates all user entry fields.  If all fields are valid, then true is returned.
    '************************************************************************************************
    Private Function validateUserFields() As Boolean
        'Declare variables
        Dim validUserData As Boolean = True
        Dim firstName As String = Nothing
        Dim lastName As String = Nothing
        Dim city As String = Nothing
        Dim usState As String = Nothing
        Dim zipCode As String = Nothing
        Dim email As String = Nothing
        Dim phone As String = Nothing

        'Set fields
        firstName = validateFirstName()
        lastName = validateLastName()
        city = validateCity()
        zipCode = validateZipCode()
        phone = validatePhone()
        email = validateEmail()
        usState = validateState()

        'Validate fields
        If firstName Is Nothing Then
            If validUserData Then
                txtFirstName.Focus()
            End If

            validUserData = False
        End If

        If lastName Is Nothing Then
            If validUserData Then
                txtLastName.Focus()
            End If

            validUserData = False

        End If

        If email Is Nothing Then
            If validUserData Then
                txtEmail.Focus()
            End If
            validUserData = False
        End If

        If phone Is Nothing Then
            If validUserData Then
                txtPhone.Focus()
            End If

            validUserData = False
        End If

        If city Is Nothing Then
            If validUserData Then
                txtCity.Focus()
            End If

            validUserData = False
        End If

        If usState Is Nothing Then
            If validUserData Then
                comboStates.Focus()
            End If
            validUserData = False
        End If

        If zipCode Is Nothing Then
            If validUserData Then
                txtZipCode.Focus()
            End If

            validUserData = False
        End If

        'Return valid information
        Return validUserData

    End Function

    '************************************************************************************************
    '*  Method validates the first name entry.  It returns the first name entry if it was valid
    '*  or nothing if it was invalid.
    '************************************************************************************************
    Private Function validateFirstName() As String
        'Declare variables
        Dim firstName As String = Nothing

        'Set variable
        firstName = Trim(txtFirstName.Text)

        'Validate variable
        If firstName.Length < minLengthFirstName Or firstName.Length > maxLengthFirstName Then
            lblErrorFirstName.Text = "must be at least " & minLengthFirstName & " characters and less than or equal to " _
                & maxLengthFirstName & " characters"
            firstName = Nothing
            txtFirstName.SelectAll()
        End If

        'Return variable
        Return firstName

    End Function

    '************************************************************************************************
    '*  Method validates the last name entry.  It returns the last name entry if it was valid
    '*  or nothing if it was invalid.
    '************************************************************************************************
    Private Function validateLastName() As String
        'Declare variables
        Dim lastName As String = Nothing

        'Set variable
        lastName = Trim(txtLastName.Text)

        'Validate variable
        If lastName.Length < minLengthLastName Or lastName.Length > maxLengthLastName Then
            lblErrorLastName.Text = "must be at least " & minLengthLastName & " characters and less than or equal to " _
                & maxLengthLastName & " characters"
            lastName = Nothing
            txtLastName.SelectAll()
        End If

        'Return variable
        Return lastName

    End Function

    '************************************************************************************************
    '*  Method validates the city entry.  It returns the city entry if it was valid
    '*  or nothing if it was invalid.
    '************************************************************************************************
    Private Function validateCity() As String
        'Declare variable
        Dim city As String = Nothing

        'Set variable
        city = Trim(txtCity.Text)

        'Validate variable
        If city.Length < minLengthCity Or city.Length > maxLengthCity Then
            lblErrorCity.Text = "must be at least " & minLengthCity & " characters and less than or equal to " _
                & maxLengthLastName & " characters"
            city = Nothing
            txtCity.SelectAll()
        End If

        'Return variable
        Return city

    End Function

    '************************************************************************************************
    '*  Method validates the zip code entry.  It returns the zip code entry if it was valid
    '*  or nothing if it was invalid.
    '************************************************************************************************
    Private Function validateZipCode() As String
        'Declare variables
        Dim zipCode As String = Nothing
        Dim zipCodePatternValid As Boolean = False

        'Set variables
        zipCode = Trim(txtZipCode.Text)
        zipCodePatternValid = (Regex.IsMatch(zipCode, "^[0-9]{5,5}$") _
                               Or Regex.IsMatch(zipCode, "^[0-9]{5,5}-[0-9]{4,4}$"))

        'Verify zip code
        If zipCode.Length < minLengthZipCode Or zipCode.Length > maxLengthZipCode Then
            lblErrorZipCode.Text = "invalid zip code (expected format: 12345 or 12345-1234)"
            zipCode = Nothing
            txtZipCode.SelectAll()

        ElseIf Not zipCodePatternValid Then
            lblErrorZipCode.Text = "invalid zip code (expected format: 12345 or 12345-1234)"
            zipCode = Nothing
            txtZipCode.SelectAll()

        End If

        'Return zip code
        Return zipCode

    End Function

    '************************************************************************************************
    '*  Method validates the phone entry.  It returns the phone entry if it was valid
    '*  or nothing if it was invalid.
    '************************************************************************************************
    Private Function validatePhone() As String
        'Declare variables
        Dim phone As String = Nothing
        Dim phonePatternValid As Boolean = False

        'Set variables
        phone = Trim(txtPhone.Text)
        phonePatternValid = Regex.IsMatch(phone, "^[0-9]{3,3}-[0-9]{3,3}-[0-9]{4,4}$")

        'Verify phone
        If phone.Length < minLengthPhone Or phone.Length > maxLengthPhone Then
            lblErrorPhone.Text = "invalid phone (expected format: 111-222-3333)"
            phone = Nothing
            txtPhone.SelectAll()

        ElseIf Not phonePatternValid Then
            lblErrorPhone.Text = "invalid phone (expected format: 111-222-3333)"
            phone = Nothing
            txtPhone.SelectAll()

        End If

        'Return phone
        Return phone

    End Function

    '************************************************************************************************
    '*  Method validates the phone entry.  It returns the phone entry if it was valid
    '*  or nothing if it was invalid.
    '************************************************************************************************
    Private Function validateEmail() As String
        'Declare variables
        Dim email As String = Nothing
        Dim emailPatternValid As Boolean = False

        'Set variables
        email = Trim(txtEmail.Text)
        emailPatternValid = Regex.IsMatch(email, "^[0-9a-zA-Z-._]+@[0-9a-zA-Z-._]+.[a-zA-Z]+$")

        'Verify email
        If email.Length < minLengthEmail Or email.Length > maxLengthEmail Then
            lblErrorEmail.Text = "must be at least " & minLengthEmail & " characters and less than or equal to " _
                & maxLengthEmail & " characters"
            txtEmail.SelectAll()
            email = Nothing

        ElseIf Not emailPatternValid Then
            lblErrorEmail.Text = "invalid email (expected format: myname@domain.com)"
            txtEmail.SelectAll()
            email = Nothing
        End If

        'Return email
        Return email

    End Function

    '************************************************************************************************
    '*  Method validates the U.S. state selection.  It returns the the state text of the selection in
    '*  the combobox if a state was selected or nothing if no state was selected. 
    '************************************************************************************************
    Private Function validateState() As String
        'Set variable
        Dim usState As String = Nothing

        'Validate state
        If comboStates.SelectedIndex < 0 Then
            lblErrorState.Text = "select a state"
            usState = Nothing
        Else
            usState = Trim(comboStates.SelectedItem.ToString)
        End If

        'Return state
        Return usState

    End Function


    '************************************************************************************************
    '*  Method clears the error text displayed in the error labels.
    '************************************************************************************************
    Private Sub clearErrors()

        'Set error label text to nothing
        lblErrorFirstName.Text = Nothing
        lblErrorLastName.Text = Nothing
        lblErrorEmail.Text = Nothing
        lblErrorPhone.Text = Nothing
        lblErrorCity.Text = Nothing
        lblErrorState.Text = Nothing
        lblErrorZipCode.Text = Nothing

    End Sub
End Class