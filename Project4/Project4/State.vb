'***************************************************************************************************
'*
'*      Class:          State          
'*      Author:         Nicole LaBonte
'*      Date Created:   December 11, 2011
'*      Description:    State stores all the attributes for a State:  _Abbreviation.  
'*                      It has a property for the Abbreviation and a read-only property
'*                      for the States list that accesses the StateDA States property.
'*                      This class has an initialize method to access the StateDA
'*                      initialize method.  It also contains a constructor that sets
'*                      the _Abbreviation variable.
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

Public Class State

    'Variables
    Private _Abbreviation As String

    'Properties
    Public Shared ReadOnly Property States() As List(Of State)
        Get
            Return StateDA.States
        End Get
    End Property

    Public Property Abbreviation() As String
        Get
            Return _Abbreviation
        End Get
        Set(ByVal value As String)
            _Abbreviation = value
        End Set
    End Property

    'Constructor
    Public Sub New(ByVal abbreviation As String)
        Me.Abbreviation = abbreviation
    End Sub

    '************************************************************************************************
    '*  Method accesses the StateDA initialize method to load the XML document, assign the root node 
    '*  from the XML document, assign the child nodes to the XML node list, and call a method to 
    '*  load the states to the States list.
    '************************************************************************************************
    Public Shared Sub initialize()
        StateDA.initialize()
    End Sub

End Class
