'***************************************************************************************************
'*
'*      Class:          AddUser         
'*      Author:         Nicole LaBonte
'*      Date Created:   December 17, 2011
'*      Description:    A form that adds a user.  This class has methods to validate the user data
'*                      entered, provide feedback to the user on the data entered, create a valid
'*                      User object, and add the User object to the XML file.
'*                      
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

'Imports
Imports System.Text.RegularExpressions

Public Class AddUser

    'Declare constants
    Const minLengthId As Integer = 1
    Const maxLengthId As Integer = 10
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

    '************************************************************************************************
    '*  Method is processed when the AddUser form is loaded.  This method calls other methods to 
    '*  populate the states in the state combobox, set the max length of the entry fields, and
    '*  clear any error labels.
    '************************************************************************************************
    Private Sub AddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Populate state list
            populateStates()

        Catch ex As Exception
            MessageBox.Show("Error loading states. Exiting...")
            Me.Close()

        End Try
       
        'Set max lengths of fields
        setFieldAttributes()

        'Clear errors
        clearErrors()

    End Sub

    '************************************************************************************************
    '*  Method sets the max length of the entry fields.
    '************************************************************************************************
    Private Sub setFieldAttributes()

        'Set max lengths of all entry fields
        txtId.MaxLength = maxLengthId
        txtFirstName.MaxLength = maxLengthFirstName
        txtLastName.MaxLength = maxLengthLastName
        txtEmail.MaxLength = maxLengthEmail
        txtPhone.MaxLength = maxLengthPhone
        txtCity.MaxLength = maxLengthCity
        txtZipCode.MaxLength = maxLengthZipCode

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
    '*  Method is processed when the add button is clicked on the AddUser form.  This method calls 
    '*  a method to clear the errors in the labels and add a user.  If the user is added successfully,
    '*  this method will display a success message box and close the form.
    '************************************************************************************************
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Declare variables
        Dim isUserAdded As Boolean = False

        'Clear error labels
        clearErrors()

        'Attempt to add user
        isUserAdded = addUser()

        'Verify if user was added
        If isUserAdded Then
            MessageBox.Show("User has been added.")
            Me.Close()
        End If

    End Sub

    '************************************************************************************************
    '*  Method closes the addUser form.
    '************************************************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    '************************************************************************************************
    '*  Method attempts to create a new user object and add this object to the XML file. If the user
    '*  is added, then true is returned from the function.
    '************************************************************************************************
    Private Function addUser() As Boolean

        'Declare variables
        Dim id As Integer = 0
        Dim firstName As String = Nothing
        Dim lastName As String = Nothing
        Dim city As String = Nothing
        Dim state As String = Nothing
        Dim zipCode As String = Nothing
        Dim email As String = Nothing
        Dim phone As String = Nothing
        Dim found As Boolean = False
        Dim aUser As User = Nothing
        Dim isUserAdded As Boolean = False
        Dim fieldError As Boolean = False

        'Add user if all fields are valid
        If validateUserFields() Then

            'Assign values
            id = obtainUserId()
            firstName = validateFirstName()
            lastName = validateLastName()
            city = validateCity()
            state = validateState()
            zipCode = validateZipCode()
            email = validateEmail()
            phone = validatePhone()

            Try
                'Create new user
                aUser = New User(id, firstName, lastName, email, phone, city, state, zipCode)

                'Add user to file
                User.addUser(aUser)

                'Set boolean
                isUserAdded = True
            Catch ex As Exception

                MessageBox.Show("Error adding user.")
                isUserAdded = False

            End Try

        Else
            'Set boolean
            isUserAdded = False
        End If

        'Return boolean
        Return isUserAdded

    End Function

    '************************************************************************************************
    '*  Method validates all user entry fields.  If all fields are valid, then true is returned.
    '************************************************************************************************
    Private Function validateUserFields() As Boolean
        'Declare variables
        Dim validUserData As Boolean = True
        Dim id As Integer = 0
        Dim firstName As String = Nothing
        Dim lastName As String = Nothing
        Dim city As String = Nothing
        Dim usState As String = Nothing
        Dim zipCode As String = Nothing
        Dim email As String = Nothing
        Dim phone As String = Nothing

        'Set fields
        id = obtainUserId()
        firstName = validateFirstName()
        lastName = validateLastName()
        city = validateCity()
        zipCode = validateZipCode()
        phone = validatePhone()
        email = validateEmail()
        usState = validateState()

        'Validate fields
        If id <= 0 Then
            validUserData = False
            txtId.Focus()
        ElseIf userExists(id) Then
            validUserData = False
            txtId.Focus()
        End If


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
    '*  Method determines if the user already exists in the XML file.  
    '*  If the user already exists, true is returned.
    '************************************************************************************************
    Private Function userExists(ByVal id As Integer) As Boolean
        'Declare variables
        Dim userFound As Boolean = False

        'Verify if user exists
        userFound = User.find(id)

        'If user exists, then display error and set to true for user found
        If userFound Then
            lblErrorId.Text = "This user id already exists."
            txtId.SelectAll()
            userFound = True
        End If

        'Return userFound boolean
        Return userFound

    End Function

    '************************************************************************************************
    '*  Method returns the id as an integer.
    '************************************************************************************************
    Private Function obtainUserId() As Integer
        'Declare variables
        Dim id As Integer = 0

        'Convert id text to integer
        Integer.TryParse(txtId.Text, id)

        'Validate id entered
        If id = 0 Then
            lblErrorId.Text = "Enter a whole number ID greater than 0."
            txtId.SelectAll()
        End If

        'Return id
        Return id

    End Function

    '************************************************************************************************
    '*  Method clears the error text displayed in the error labels.
    '************************************************************************************************
    Private Sub clearErrors()

        'Set error label text to nothing
        lblErrorId.Text = Nothing
        lblErrorFirstName.Text = Nothing
        lblErrorLastName.Text = Nothing
        lblErrorEmail.Text = Nothing
        lblErrorPhone.Text = Nothing
        lblErrorCity.Text = Nothing
        lblErrorState.Text = Nothing
        lblErrorZipCode.Text = Nothing

    End Sub

End Class