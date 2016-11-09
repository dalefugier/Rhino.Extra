/////////////////////////////////////////////////////////////////////////////
// RhinoExtraLib.h
//

#pragma once

#if defined (USING_RH_C_SDK)
#define RH_CPP_FUNCTION __declspec(dllimport)
#define RH_CPP_CLASS __declspec(dllimport)
#define RH_EXPORT __declspec(dllimport)
#else
#define RH_CPP_FUNCTION __declspec(dllexport)
#define RH_CPP_CLASS __declspec(dllexport)
#define RH_EXPORT __declspec(dllexport)
#endif

#define RH_C_FUNCTION extern "C" __declspec(dllexport)

#define INPUTSTRINGCOERCE(_variablename, _parametername) \
const wchar_t* _variablename = _parametername;

class RH_CPP_FUNCTION CStringHolder
{
public:
  void Set(const ON_wString& str);
  const wchar_t* Array() const;
private:
  ON_wString m_string;
};

struct ON_3DPOINT_STRUCT
{ 
  double val[3]; 
};

struct ON_2DPOINT_STRUCT
{ 
  double val[2]; 
};