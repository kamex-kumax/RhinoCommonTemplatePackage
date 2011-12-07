﻿$if$ ($notutility$ == 1)Imports System
Imports Rhino

$endif$Namespace $safeprojectname$
    '''<summary>
    ''' <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    ''' class. DO NOT create instances of this class yourself. It is the
    ''' responsibility of Rhino to create an instance of this class.</para>
    ''' <para>To complete plug-in information, please also see all PlugInDescription
    ''' attributes in AssemblyInfo.vb (you might need to click "Project" ->
    ''' "Show All Files" to see it in the "Solution Explorer" window).</para>
    '''</summary>
    Public Class $pluginname$
$if$ ($utility$ == 1)        Inherits Rhino.PlugIns.PlugIn
$endif$$if$ ($digitizer$ == 1)        Inherits Rhino.PlugIns.DigitizerPlugIn
$endif$$if$ ($rendering$ == 1)        Inherits Rhino.PlugIns.RenderPlugIn
$endif$$if$ ($import$ == 1)        Inherits Rhino.PlugIns.FileImportPlugIn
$endif$$if$ ($export$ == 1)        Inherits Rhino.PlugIns.FileExportPlugIn
$endif$
        Shared _instance As $pluginname$

        Public Sub New()
            _instance = Me
        End Sub

        '''<summary>Gets the only instance of the $pluginname$ plug-in.</summary>
        Public Shared ReadOnly Property Instance() As $pluginname$
            Get
                Return _instance
            End Get
        End Property
$if$ ($digitizer$ == 1)
        '''<summary>
        ''' Defines the behavior in response to a request of a user to either enable or disable
        ''' input from the digitizer.
        ''' It is called by Rhino. If enable is true and EnableDigitizer() returns false,
        ''' then Rhino will not calibrate the digitizer.
        '''</summary>
        '''<param name="enable">If true, enable the digitizer. If false, disable the digitizer.</param>
        '''<returns>You should return true if the digitizer should be calibrated. Otherwise, false.</returns>
        Protected Overrides Function EnableDigitizer(enable As Boolean) As Boolean
	        Throw New NotImplementedException("EnableDigitizer has no defined behavior in the $safeprojectname$.$pluginname$ class.")
        End Function

        '''<summary>
        ''' Gets the unit system in which the digitizer works.
        ''' passes points to SendPoint().  Rhino uses this value when it calibrates a digitizer.
        ''' This unit system must not change.
        ''' </summary>
        Protected Overrides ReadOnly Property DigitizerUnitSystem() As UnitSystem
	        Get
		        Throw New NotImplementedException("DigitizerUnitSystem is not implemented in the $safeprojectname$.$pluginname$ class.")
	        End Get
        End Property

        ''' <summary>
        ''' Gets the point tolerance, or the distance the digitizer must move (in digitizer
        ''' coordinates) for a new point to be considered real rather than noise. Small
        ''' desktop digitizer arms have values like 0.001 inches and 0.01 millimeters.
        ''' This value should never be smaller than the accuracy of the digitizing device.
        ''' </summary>
        Protected Overrides ReadOnly Property PointTolerance() As Double
	        Get
		        Throw New NotImplementedException("PointTolerance is unknown in the $safeprojectname$.$pluginname$ class.")
	        End Get
        End Property
$endif$$if$ ($import$ == 1)
        '''<summary>Defines file extensions that this import plug-in is designed to read.</summary>
        ''' <param name="options">Options that specify how to read files.</param>
        ''' <returns>A list of file types that can be imported.</returns>
        Protected Overrides Function AddFileTypes(options As Rhino.FileIO.FileReadOptions) As Rhino.PlugIns.FileTypeList
	        Dim result = New Rhino.PlugIns.FileTypeList()
	        result.AddFileType("$description$ (*.$extension$)", "$extension$")
	        Return result
        End Function

        ''' <summary>
        ''' Is called when a user requests to import a ."$extension$ file.
        ''' It is actually up to this method to read the file itself.
        ''' </summary>
        ''' <param name="filename">The complete path to the new file.</param>
        ''' <param name="index">The index of the file type as it had been specified by the AddFileTypes method.</param>
        ''' <param name="doc">The document to be written.</param>
        ''' <param name="options">Options that specify how to write file.</param>
        ''' <returns>A value that defines success or a specific failure.</returns>
        Protected Overrides Function ReadFile(filename As String, index As Integer, doc As RhinoDoc, options As Rhino.FileIO.FileReadOptions) As Boolean
	        Dim read_success As Boolean = False
	        ' TODO: Add code for reading file
	        Return read_success
        End Function
$endif$$if$ ($export$ == 1)
        ''' <summary>Defines file extensions that this export plug-in is designed to write.</summary>
        ''' <param name="options">Options that specify how to write files.</param>
        ''' <returns>A list of file types that can be exported.</returns>
        Protected Overrides Function AddFileTypes(options As Rhino.FileIO.FileWriteOptions) As Rhino.PlugIns.FileTypeList
	        Dim result = New Rhino.PlugIns.FileTypeList()
	        result.AddFileType("$description$ (*.$extension$)", "$extension$")
	        Return result
        End Function

        ''' <summary>
        ''' Is called when a user requests to export a ."$extension$ file.
        ''' It is actually up to this method to write the file itself.
        ''' </summary>
        ''' <param name="filename">The complete path to the new file.</param>
        ''' <param name="index">The index of the file type as it had been specified by the AddFileTypes method.</param>
        ''' <param name="doc">The document to be written.</param>
        ''' <param name="options">Options that specify how to write file.</param>
        ''' <returns>A value that defines success or a specific failure.</returns>
        Protected Overrides Function WriteFile(filename As String, index As Integer, doc As RhinoDoc, options As Rhino.FileIO.FileWriteOptions) As Rhino.PlugIns.WriteFileResult
	        Return Rhino.PlugIns.WriteFileResult.Failure
        End Function
$endif$$if$ ($rendering$ == 1)
        ''' <summary>
        ''' Is called when the user calls the _Render command.
        ''' </summary>
        ''' <param name="doc">The document to be rendered.</param>
        ''' <param name="mode">The run mode: interactive or scripted.</param>
        ''' <param name="fastPreview">Whether the render is in preview-mode.</param>
        ''' <returns>The result of the command.</returns>
        Protected Overrides Function Render(doc As RhinoDoc, mode As Rhino.Commands.RunMode, fastPreview As Boolean) As Rhino.Commands.Result
            Throw New NotImplementedException("Render is not implemented in the $safeprojectname$.$pluginname$ class.")
        End Function

        ''' <summary>
        ''' Is called when the user calls the _RenderWindow command.
        ''' </summary>
        ''' <param name="doc">The document to be rendered.</param>
        ''' <param name="mode">The run mode: interactive or scripted.</param>
        ''' <param name="fastPreview">Whether the render is in preview-mode.</param>
        ''' <param name="view">The view being rendered.</param>
        ''' <param name="rect">The rendering rectangle.</param>
        ''' <param name="inWindow">Whether rendering should appear in the window.</param>
        ''' <returns>The result of the command.</returns>
        Protected Overrides Function RenderWindow(doc As RhinoDoc, mode As Rhino.Commands.RunMode, fastPreview As Boolean, view As Rhino.Display.RhinoView, rect As System.Drawing.Rectangle, inWindow As Boolean) As Rhino.Commands.Result
            throw new NotImplementedException("RenderWindow is not implemented in the $safeprojectname$.$pluginname$ class.")
        End Function
$endif$

        ' You can override methods here to change the plug-in behavior on
        ' loading and shut down, add options pages to the Rhino _Option command
        ' and mantain plug-in wide options in a document.
    End Class
End Namespace