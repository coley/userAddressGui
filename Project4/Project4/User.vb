'***************************************************************************************************
'*
'*      Class:          User        
'*      Author:         Nicole LaBonte
'*      Date Created:   December 17, 2011
'*      Description:    User stores all the attributes for a User:  _Id, _FirstName, _LastName,
'*                      _Email, _Phone, _City, _State, and _ZipCode.  It contains public properties
'*                      for each of these attributes.  It also contains a constructor that
'*                      sets each of these attributes.  This class has methods that access
'*                      the UserDA methods of initialize, getUser, terminate, find, updateUser,
'*                      addUser, and deleteUser.  It also has public properties to access
'*                      the UserDA properties of CurrentUserIndex and UserCount.
'*                      
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

Public Class User

    'Public properties
    Public Property Id() As Integer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property Email() As String
    Public Property Phone() As String
    Public Property City() As String
    Public Property State() As String
    Public Property ZipCode() As String

    Public Shared Property CurrentUserIndex() As Integer
        Get
            Return UserDA.CurrentUserIndex
        End Get
        Set(ByVal value As Integer)
            UserDA.CurrentUserIndex = value
        End Set
    End Property

    Public Shared ReadOnly Property UserCount() As Integer
        Get
            Return UserDA.UserCount
        End Get
    End Property

    'Constructor
    Public Sub New(ByVal id As Integer,
                   ByVal firstName As String,
                   ByVal lastName As String,
                   ByVal email As String,
                   ByVal phone As String,
                   ByVal city As String,
                   ByVal state As String,
                   ByVal zipCode As String)

        Me.Id = id
        Me.FirstName = firstName
        Me.LastName = lastName
        Me.Email = email
        Me.Phone = phone
        Me.City = city
        Me.State = state
        Me.ZipCode = zipCode

    End Sub

    '************************************************************************************************
    '*  Method accesses the UserDA initialize method, which loads the XML document, assigns the 
    '*  root node from the XML document, assigns the child nodes to the XML node list, and 
    '*  sets the current user index to 0.
    '************************************************************************************************
    Public Shared Sub initialize()
        UserDA.initialize()
    End Sub

    '************************************************************************************************
    '*  Method accesses the UserDA terminate method to save the XML file data.
    '************************************************************************************************
    Public Shared Sub terminate()
        UserDA.terminate()
    End Sub

    '************************************************************************************************
    '*  Method accesses the UserDA getUser method to return a user object.  It creates a new user 
    '*  object and assigns values to this object based on the user node corresponding to the the 
    '*  current user index value.
    '************************************************************************************************
    Public Shared Function getUser() As User
        Return UserDA.getUser()
    End Function

    '************************************************************************************************
    '*  Method accesses the UserDA find method to return true if the id parameter corresponds to an 
    '*  id of a user within the XML file.
    '************************************************************************************************
    Public Shared Function find(ByVal id As Integer) As Boolean
        Return UserDA.find(id)
    End Function

    '************************************************************************************************
    '*  Method accesses the UserDA updateUser method to update an existing user within the XML file.  
    '*  After update, the file is saved.
    '************************************************************************************************
    Public Shared Sub updateUser(ByVal aUser As User)
        UserDA.updateUser(aUser)
    End Sub

    '************************************************************************************************
    '*  Method accesses the UserDA addUser method to add a new user to the XML file.  
    '*  After addition, the file is saved.
    '************************************************************************************************
    Public Shared Sub addUser(ByVal aUser As User)
        UserDA.addUser(aUser)
    End Sub

    '************************************************************************************************
    '*  Method accesses the UserDA delete method to delete an existing user from the XML file.  
    '*  After deletion, the file is saved.
    '************************************************************************************************
    Public Shared Sub deleteUser()
        UserDA.deleteUser()
    End Sub
End Class
