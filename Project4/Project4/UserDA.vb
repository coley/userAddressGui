'***************************************************************************************************
'*
'*      Class:          UserDA        
'*      Author:         Nicole LaBonte
'*      Date Created:   December 17, 2011
'*      Description:    UserDA is a data adapter class for the User.  It reads User data from an 
'*                      XML file and contains methods to initialize the file, terminate and save
'*                      the file, get user, set name node, set address node, find user,
'*                      update user, add user, and delete user.  It also contains a public
'*                      property for CurrentUserIndex and a read only property for UserCount.
'*                      
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

'Imports
Imports System.Xml

Public Class UserDA

    'Constants
    Const fileLocation As String = "..\..\userData.xml"
    Const userId As String = "id"
    Const userName As String = "name"
    Const userFirstName As String = "first"
    Const userLastName As String = "last"
    Const userAddress As String = "address"
    Const userCity As String = "city"
    Const userState As String = "state"
    Const userZipCode As String = "zipCode"
    Const userEmail As String = "email"
    Const userPhone As String = "phone"
    Const user As String = "user"

    'Variables
    Private Shared _UserDocument As XmlDocument
    Private Shared _UsersNode As XmlNode
    Private Shared _NameNode As XmlNode
    Private Shared _AddressNode As XmlNode
    Private Shared _UserList As XmlNodeList
    Private Shared _CurrentUserIndex As Integer

    'Properties
    Public Shared Property CurrentUserIndex() As Integer
        Get
            Return _CurrentUserIndex
        End Get
        Set(ByVal value As Integer)
            _CurrentUserIndex = value
        End Set
    End Property

    Public Shared ReadOnly Property UserCount() As Integer
        Get
            Return _UserList.Count
        End Get
    End Property

    '************************************************************************************************
    '*  Method loads the XML document, assigns the root node from the XML document, assigns the
    '*  child nodes to the XML node list, and sets the current user index to 0.
    '************************************************************************************************
    Public Shared Sub initialize()
        'Create XML Document
        _UserDocument = New XmlDocument

        'Load user data from XML file
        _UserDocument.Load(fileLocation)

        'Assign root node
        _UsersNode = _UserDocument.DocumentElement

        'Assign child nodes
        _UserList = _UsersNode.ChildNodes

        'Set current user
        CurrentUserIndex = 0
    End Sub

    '************************************************************************************************
    '*  Method saves the XML file data.
    '************************************************************************************************
    Public Shared Sub terminate()
        _UserDocument.Save(fileLocation)
    End Sub

    '************************************************************************************************
    '*  Method returns a user object.  It creates a new user object and assigns values to this object
    '*  based on the user node corresponding to the the current user index value.
    '************************************************************************************************
    Public Shared Function getUser() As User
        'Declare variables
        Dim id As Integer
        Dim firstName As String
        Dim lastName As String
        Dim email As String
        Dim phone As String
        Dim city As String
        Dim state As String
        Dim zipCode As String
        Dim aUser As User
        Dim currentUserNode As XmlNode

        'Set current user node
        currentUserNode = _UserList(_CurrentUserIndex)

        'Set name and address nodes
        setNameNode(currentUserNode)
        setAddressNode(currentUserNode)

        'Assign values based on current user node
        id = CInt(currentUserNode(userId).InnerText)
        firstName = _NameNode(userFirstName).InnerText
        lastName = _NameNode(userLastName).InnerText
        email = currentUserNode(userEmail).InnerText
        phone = currentUserNode(userPhone).InnerText
        city = _AddressNode(userCity).InnerText
        state = _AddressNode(userState).InnerText
        zipCode = _AddressNode(userZipCode).InnerText

        'Create user
        aUser = New User(id, firstName, lastName, email, phone, city, state, zipCode)

        'Return user object
        Return aUser

    End Function

    '************************************************************************************************
    '*  Method sets the name node instance variable based on the current user node value.
    '************************************************************************************************
    Private Shared Sub setNameNode(ByVal currentUserNode As XmlNode)
        _NameNode = currentUserNode(userName)
    End Sub

    '************************************************************************************************
    '*  Method sets the address node instance variable based on the current user node value.
    '************************************************************************************************
    Private Shared Sub setAddressNode(ByVal currentUserNode As XmlNode)
        _AddressNode = currentUserNode(userAddress)
    End Sub

    '************************************************************************************************
    '*  Method returns true if the id parameter corresponds to an id of a user within the XML file.
    '************************************************************************************************
    Public Shared Function find(ByVal id As Integer) As Boolean
        Dim userNode As XmlNode = Nothing
        Dim path As String = Nothing
        Dim found As Boolean = False

        path = "//" & user & " [" & userId & " = " & id & "]"

        userNode = _UsersNode.SelectSingleNode(path)

        If userNode Is Nothing Then
            found = False
        Else
            found = True
        End If

        Return found

    End Function

    '************************************************************************************************
    '*  Method updates an existing user within the XML file.  After update, the file is saved.
    '************************************************************************************************
    Public Shared Sub updateUser(ByVal aUser As User)
        'Declare variables
        Dim currentUserNode As XmlNode

        'Set user node
        currentUserNode = _UserList(_CurrentUserIndex)

        'Set name and address nodes
        setNameNode(currentUserNode)
        setAddressNode(currentUserNode)

        'Assign values based on current user node
        currentUserNode(userId).InnerText = aUser.Id.ToString
        _NameNode(userFirstName).InnerText = aUser.FirstName
        _NameNode(userLastName).InnerText = aUser.LastName
        currentUserNode(userEmail).InnerText = aUser.Email
        currentUserNode(userPhone).InnerText = aUser.Phone
        _AddressNode(userCity).InnerText = aUser.City
        _AddressNode(userState).InnerText = aUser.State
        _AddressNode(userZipCode).InnerText = aUser.ZipCode

        'Save file
        terminate()

    End Sub

    '************************************************************************************************
    '*  Method adds a new user to the XML file.  After addition, the file is saved.
    '************************************************************************************************
    Public Shared Sub addUser(ByVal aUser As User)
        Dim userElement As XmlElement
        Dim idElement As XmlElement
        Dim firstNameElement As XmlElement
        Dim lastNameElement As XmlElement
        Dim emailElement As XmlElement
        Dim phoneElement As XmlElement
        Dim cityElement As XmlElement
        Dim stateElement As XmlElement
        Dim zipCodeElement As XmlElement
        Dim nameElement As XmlElement
        Dim addressElement As XmlElement

        'Set elements
        userElement = _UserDocument.CreateElement(user)
        nameElement = _UserDocument.CreateElement(userName)
        addressElement = _UserDocument.CreateElement(userAddress)
        idElement = _UserDocument.CreateElement(userId)
        firstNameElement = _UserDocument.CreateElement(userFirstName)
        lastNameElement = _UserDocument.CreateElement(userLastName)
        emailElement = _UserDocument.CreateElement(userEmail)
        phoneElement = _UserDocument.CreateElement(userPhone)
        cityElement = _UserDocument.CreateElement(userCity)
        stateElement = _UserDocument.CreateElement(userState)
        zipCodeElement = _UserDocument.CreateElement(userZipCode)

        'Append to top level node
        _UsersNode.AppendChild(userElement)

        'Append id
        userElement.AppendChild(idElement)

        'Append name node information
        userElement.AppendChild(nameElement)

        'Append first and last name
        nameElement.AppendChild(firstNameElement)
        nameElement.AppendChild(lastNameElement)

        'Append address node information
        userElement.AppendChild(addressElement)

        'Append city, state, zip
        addressElement.AppendChild(cityElement)
        addressElement.AppendChild(stateElement)
        addressElement.AppendChild(zipCodeElement)

        'Append email
        userElement.AppendChild(emailElement)

        'Append phone
        userElement.AppendChild(phoneElement)

        'Set inner text of all elements
        idElement.InnerText = aUser.Id.ToString
        firstNameElement.InnerText = aUser.FirstName
        lastNameElement.InnerText = aUser.LastName
        cityElement.InnerText = aUser.City
        stateElement.InnerText = aUser.State
        zipCodeElement.InnerText = aUser.ZipCode
        emailElement.InnerText = aUser.Email
        phoneElement.InnerText = aUser.Phone

        'Save data
        terminate()

        'Set index to max index to see newly added user
        _CurrentUserIndex = _UserList.Count - 1

    End Sub

    '************************************************************************************************
    '*  Method deletes an existing user from the XML file.  After deletion, the file is saved.
    '************************************************************************************************
    Public Shared Sub deleteUser()
        'Declare variables
        Dim currentUserNode As XmlNode

        'Set user node
        currentUserNode = _UserList(_CurrentUserIndex)

        'Remove user
        _UsersNode.RemoveChild(currentUserNode)

        'Update current index
        If _CurrentUserIndex > 0 Then
            _CurrentUserIndex = _CurrentUserIndex - 1
        Else
            _CurrentUserIndex = 0
        End If

        'Save updates
        terminate()

    End Sub


End Class
