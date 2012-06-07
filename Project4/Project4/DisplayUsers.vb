'***************************************************************************************************
'*
'*      Class:          DisplayUsers         
'*      Author:         Nicole LaBonte
'*      Date Created:   December 17, 2011
'*      Description:    A form that displays all users.  This form contains methods to page through
'*                      users with first, next, previous, and last buttons.  It also contains methods
'*                      to add a new user, update a selected user, and delete a selected user.  
'*                      
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

Public Class DisplayUsers


    '************************************************************************************************
    '*  Method is processed when the DisplayUsers form is loaded.  This method calls other methods to 
    '*  populate the states in the state combobox, intitialize all users (obtain user data from 
    '*  XML file, display current user, and determine the user actions available.  Exceptions
    '*  will display a message box with an error.
    '************************************************************************************************
    Private Sub DisplayUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Populate states
            populateStates()

            'Initialize all users
            User.initialize()

            'Display User
            displayUser()

            'Determine if updatea and delete buttons appear
            userActionsAvailable()

        Catch ex As Exception

            MessageBox.Show("Error loading user information. Exiting...")
            Me.Close()

        End Try

    End Sub

    '************************************************************************************************
    '*  Method determines if the update user and delete user buttons are visible.  Their visibility
    '*  is set to true if there are 1 or more users in the XML file.
    '************************************************************************************************
    Private Sub userActionsAvailable()

        If User.UserCount > 0 Then
            btnUpdateUser.Visible = True
            btnDeleteUser.Visible = True
        Else
            btnUpdateUser.Visible = False
            btnDeleteUser.Visible = False
        End If

    End Sub

    '************************************************************************************************
    '*  Method displays the currently selected user's information in the form fields.  If no
    '*  users exist, then the form fields are set appropriately.
    '************************************************************************************************
    Private Sub displayUser()
        Dim aUser As User

        If User.UserCount > 0 Then
            'Retrieve user
            aUser = User.getUser

            'Assign user to form
            lblId.Text = aUser.Id.ToString
            lblFirstName.Text = aUser.FirstName
            lblLastName.Text = aUser.LastName
            lblEmail.Text = aUser.Email
            lblPhone.Text = aUser.Phone
            lblCity.Text = aUser.City
            lblZipCode.Text = aUser.ZipCode

            'Select state in combo box
            setUserState(aUser)

            'Set record label text
            lblRecord.Text = (User.CurrentUserIndex + 1) & " of " & User.UserCount

        Else

            lblId.Text = "No users exist."
            lblFirstName.Text = Nothing
            lblLastName.Text = Nothing
            lblEmail.Text = Nothing
            lblPhone.Text = Nothing
            lblCity.Text = Nothing
            lblZipCode.Text = Nothing
            comboStates.SelectedIndex = -1
            lblRecord.Text = "no records"

        End If

    End Sub

    '************************************************************************************************
    '*  Method sets the user's state in the state combobox to match the state for the user object.
    '************************************************************************************************
    Private Sub setUserState(ByVal aUser As User)
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
    '*  Method populates the states combobox with all the states from the State XML file.
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
    '*  Method updates the current user index to the first user and calls a method to display the
    '*  newly selected user.
    '************************************************************************************************
    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        'Set index
        User.CurrentUserIndex = 0

        'Display user
        displayUser()
    End Sub

    '************************************************************************************************
    '*  Method updates the current user index to the prior user and calls a method to display the
    '*  newly selected user.
    '************************************************************************************************
    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click

        'Set index and check for 0
        If User.CurrentUserIndex > 0 Then
            User.CurrentUserIndex -= 1
        End If

        'Display user
        displayUser()

    End Sub

    '************************************************************************************************
    '*  Method updates the current user index to the next user and calls a method to display the
    '*  newly selected user.
    '************************************************************************************************
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'Set index and check for end
        If User.CurrentUserIndex < User.UserCount - 1 Then
            User.CurrentUserIndex += 1
        End If

        'Display user
        displayUser()

    End Sub

    '************************************************************************************************
    '*  Method updates the current user index to the last user and calls a method to display the
    '*  newly selected user.
    '************************************************************************************************
    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click

        'Set index to end
        User.CurrentUserIndex = User.UserCount - 1

        'Display user
        displayUser()

    End Sub


    '************************************************************************************************
    '*  Method displays the Update Form for updating the currently selected user.  After the
    '*  update, the display user method is called to display the updated user.
    '************************************************************************************************
    Private Sub btnUpdateUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateUser.Click
        Dim updateForm As New UpdateUser

        updateForm.aUser = User.getUser
        updateForm.ShowDialog()

        displayUser()

    End Sub

    '************************************************************************************************
    '*  Method displays the Add User Form for adding a new user.  After the
    '*  addition, the display user method is called to display the newly added user.
    '************************************************************************************************
    Private Sub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click
        Dim addForm As New AddUser

        'Show add user form
        addForm.ShowDialog()

        'Determine if update and delete buttons appear
        userActionsAvailable()

        'Display added user
        displayUser()


    End Sub

    '************************************************************************************************
    '*  Method displays a message box to confirm the deletion of the selected user.  If the deletion
    '*  is confirmed, then the user is deleted from the XML file.  The display user method is then
    '*  called to update the user display.  Exceptions will display a message box with an error.
    '************************************************************************************************
    Private Sub btnDeleteUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteUser.Click
        Dim result As DialogResult

        'Display message box to confirm deletion
        result = MessageBox.Show("Do you want to delete this user?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'Delete user if confirmed
        If result = DialogResult.Yes Then

            Try
                User.deleteUser()
                MessageBox.Show("User has been deleted.")

            Catch ex As Exception

                MessageBox.Show("Error. User could not be deleted.")

            End Try

        End If

        'Display users
        displayUser()

        'Determine user action buttons available
        userActionsAvailable()

    End Sub
End Class
