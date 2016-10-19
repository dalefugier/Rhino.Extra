/////////////////////////////////////////////////////////////////////////////
// RhinoExtraLibApp.cpp
//

#include "stdafx.h"
#include "RhinoExtraLibApp.h"

// CRhinoExtraLibApp

BEGIN_MESSAGE_MAP(CRhinoExtraLibApp, CWinApp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CRhinoExtraLibApp construction

CRhinoExtraLibApp::CRhinoExtraLibApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

// The one and only CRhinoExtraLibApp object
CRhinoExtraLibApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CRhinoExtraLibApp initialization

BOOL CRhinoExtraLibApp::InitInstance()
{
  // CRITICAL: DO NOT CALL RHINO SDK FUNCTIONS HERE!
	CWinApp::InitInstance();
	return TRUE;
}

int CRhinoExtraLibApp::ExitInstance()
{
  // CRITICAL: DO NOT CALL RHINO SDK FUNCTIONS HERE!
  return CWinApp::ExitInstance();
}
