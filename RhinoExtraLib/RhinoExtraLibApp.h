/////////////////////////////////////////////////////////////////////////////
// RhinoExtraLibApp.h
//

#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "Resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CRhinoExtraLibApp
// See RhinoExtraLibApp.cpp for the implementation of this class
//

class CRhinoExtraLibApp : public CWinApp
{
public:
	CRhinoExtraLibApp();

// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();
	DECLARE_MESSAGE_MAP()
};
