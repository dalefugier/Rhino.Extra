/////////////////////////////////////////////////////////////////////////////
// RhinoExtraLib.cpp
//

#include "stdafx.h"
#include "RhinoExtraLib.h"

void CStringHolder::Set(const ON_wString& str)
{
  m_string = str;
}

const wchar_t* CStringHolder::Array() const
{
  return m_string.Array();
}

// StringHolder interface

RH_C_FUNCTION CStringHolder* StringHolder_New()
{
  return new CStringHolder();
}

RH_C_FUNCTION void StringHolder_Delete(CStringHolder* pHolder)
{
  if (nullptr != pHolder)
    delete pHolder;
}

RH_C_FUNCTION const wchar_t* StringHolder_Get(CStringHolder* pHolder)
{
  const wchar_t* rc = nullptr;
  if (nullptr != pHolder)
    rc = pHolder->Array();
  return rc;
}

// ArrayString interface

RH_C_FUNCTION ON_ClassArray<ON_wString>* ArrayString_New()
{
  return new ON_ClassArray<ON_wString>();
}

RH_C_FUNCTION void ArrayString_Delete(ON_ClassArray<ON_wString>* pStrings)
{
  if (nullptr != pStrings)
    delete pStrings;
}

RH_C_FUNCTION int ArrayString_Count(const ON_ClassArray<ON_wString>* pStrings)
{
  if (nullptr != pStrings)
    return pStrings->Count();
  return 0;
}

RH_C_FUNCTION void ArrayString_Get(const ON_ClassArray<ON_wString>* pStrings, int index, CStringHolder* pHolder)
{
  if (nullptr != pStrings && index >= 0 && index < pStrings->Count() && nullptr != pHolder )
  {
    pHolder->Set((*pStrings)[index]);
  }
}

// ArrayUint interface

RH_C_FUNCTION ON_SimpleArray<unsigned int>* ArrayUint_New()
{
  return new ON_SimpleArray<unsigned int>();
}

RH_C_FUNCTION void ArrayUint_Delete(ON_SimpleArray<unsigned int>* pArray)
{
  if (nullptr != pArray)
    delete pArray;
}

RH_C_FUNCTION int ArrayUint_Count(const ON_SimpleArray<unsigned int>* pArray)
{
  return (nullptr != pArray ? pArray->Count() : 0);
}

RH_C_FUNCTION unsigned int ArrayUint_UnsignedCount(const ON_SimpleArray<unsigned int>* pArray)
{
  return (nullptr != pArray ? pArray->UnsignedCount() : 0);
}

RH_C_FUNCTION void ArrayUint_CopyValues(const ON_SimpleArray<unsigned int>* pArray, /*ARRAY*/unsigned int* pValues)
{
  if (nullptr != pArray && nullptr != pValues)
  {
    unsigned int count = pArray->UnsignedCount();
    if (count > 0)
    {
      const unsigned int* source = pArray->Array();
      ::memcpy(pValues, source, count * sizeof(pValues[0]));
    }
  }
}

// CRhinoWorksession interface

RH_C_FUNCTION int CRhinoWorkSession_WorksessionSerialNumbers(ON_SimpleArray<unsigned int>* pArray)
{
  int rc = 0;
  if (nullptr != pArray)
    rc = CRhinoWorkSession::GetActiveWorksessionRuntimeSerialNumbers(*pArray);
  return rc;
}

RH_C_FUNCTION bool CRhinoWorkSession_FileName(unsigned int serialno, CStringHolder* pHolder)
{
  bool rc = false;
  if (nullptr != pHolder)
  {
    ON_wString filename;
    rc = CRhinoWorkSession::FileName(serialno, filename);
    if (rc)
      pHolder->Set(filename);
  }
  return false;
}

RH_C_FUNCTION int CRhinoWorkSession_ModelCount(unsigned int serialno)
{
  return CRhinoWorkSession::ModelCount(serialno);
}

RH_C_FUNCTION int CRhinoWorkSession_ModelNames(unsigned int serialno, ON_ClassArray<ON_wString>* pStrings)
{
  int rc = 0;
  if (nullptr != pStrings)
    rc = CRhinoWorkSession::ModelNames(serialno, *pStrings);
  return rc;
}

RH_C_FUNCTION int CRhinoWorkSession_ModelAliases(unsigned int serialno, ON_ClassArray<ON_wString>* pStrings)
{
  int rc = 0;
  if (nullptr != pStrings)
    rc = CRhinoWorkSession::ModelAliases(serialno, *pStrings);
  return rc;
}
