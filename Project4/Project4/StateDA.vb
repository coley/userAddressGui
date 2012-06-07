'***************************************************************************************************
'*
'*      Class:          StatesDA          
'*      Author:         Nicole LaBonte
'*      Date Created:   December 11, 2011
'*      Description:    A State Data Adapter class for the State.  
'*
'*                      The StateDA class will read in the states.xml
'*                      Properties:
'*                          -shared arraylist variable with a shared readonly property
'*
'*                      Methods:
'*                          -initialize:  load the document with the states.xml file contents and navigete 
'*                           through the states, loading each innertext value to the arraylist.
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

'Imports
Imports System.Xml

Public Class StateDA

    'Constants
    Const fileLocation As String = "..\..\states.xml"

    'Variables
    Private Shared _StateDocument As XmlDocument
    Private Shared _StateNode As XmlNode
    Private Shared _StateNodeList As XmlNodeList
    Private Shared _States As List(Of State)

    'Properties
    Public Shared ReadOnly Property States() As List(Of State)
        Get
            Return _States
        End Get
    End Property

    '************************************************************************************************
    '*  Method loads the XML document, assigns the root node from the XML document, assigns the
    '*  child nodes to the XML node list, and calls a method to load the states to the States list.
    '************************************************************************************************
    Public Shared Sub initialize()
        'Instantiate State Document
        _StateDocument = New XmlDocument

        'Instantiate arraylist of states
        _States = New List(Of State)

        'Load states from xml document
        _StateDocument.Load(fileLocation)

        'Set Node and Node List
        _StateNode = _StateDocument.DocumentElement
        _StateNodeList = _StateNode.ChildNodes

        'Load all states to arraylist
        loadStates()
    End Sub


    '************************************************************************************************
    '*  Method loads the states from the XML file to the States list instance variable.
    '************************************************************************************************
    Private Shared Sub loadStates()
        'Declare variables
        Dim index As Integer
        Dim aState As State
        Dim stateAbbreviation As String
        Dim currentNode As XmlNode

        'Loop through all states and load to arraylist
        For index = 0 To _StateNodeList.Count - 1
            'Set current node to index
            currentNode = _StateNodeList(index)

            'Set state abbreviation
            stateAbbreviation = currentNode.ChildNodes(0).InnerText

            'Create new state object
            aState = New State(stateAbbreviation)

            'Add state to arraylist
            _States.Add(aState)
        Next

    End Sub


End Class
