
using System;
using System.Collections;
using System.Collections.Generic;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;

public class AttributeAdapter:CrossBindingAdaptor
{
public override Type BaseCLRType
{
    get
    {
        return typeof(System.Attribute);//这是你想继承的那个类
    }
}
public override Type AdaptorType
{
    get
    {
        return typeof(Adaptor);//这是实际的适配器类
    }
}
public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
{
    return new Adaptor(appdomain, instance);//创建一个新的实例
}
//实际的适配器类需要继承你想继承的那个类，并且实现CrossBindingAdaptorType接口
public class Adaptor : System.Attribute, CrossBindingAdaptorType
{
    ILTypeInstance instance;
    ILRuntime.Runtime.Enviorment.AppDomain appdomain;
    //缓存这个数组来避免调用时的GC Alloc
    object[] param1 = new object[1];
    public Adaptor()
    {

    }
    public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        this.appdomain = appdomain;
        this.instance = instance;
    }
    public ILTypeInstance ILInstance { get { return instance; } }
bool m_bEqualsGot = false;
IMethod m_Equals = null;
public  System.Boolean Equals (System.Object arg0)
{
   if(!m_bEqualsGot)
   {
       m_Equals = instance.Type.GetMethod("Equals",1);
       m_bEqualsGot = true;
   }
          if(m_Equals != null)
       {
           return(System.Boolean) appdomain.Invoke(m_Equals, instance,arg0);
        }
       else
       {
           return null;
       } 
}
bool m_bGetHashCodeGot = false;
IMethod m_GetHashCode = null;
public  System.Int32 GetHashCode ()
{
   if(!m_bGetHashCodeGot)
   {
       m_GetHashCode = instance.Type.GetMethod("GetHashCode",0);
       m_bGetHashCodeGot = true;
   }
          if(m_GetHashCode != null)
       {
           return(System.Int32) appdomain.Invoke(m_GetHashCode, instance,null);
        }
       else
       {
           return null;
       } 
}
bool m_bget_TypeIdGot = false;
IMethod m_get_TypeId = null;
public  System.Object get_TypeId ()
{
   if(!m_bget_TypeIdGot)
   {
       m_get_TypeId = instance.Type.GetMethod("get_TypeId",0);
       m_bget_TypeIdGot = true;
   }
          if(m_get_TypeId != null)
       {
           return(System.Object) appdomain.Invoke(m_get_TypeId, instance,null);
        }
       else
       {
           return null;
       } 
}
bool m_bMatchGot = false;
IMethod m_Match = null;
public  System.Boolean Match (System.Object arg0)
{
   if(!m_bMatchGot)
   {
       m_Match = instance.Type.GetMethod("Match",1);
       m_bMatchGot = true;
   }
          if(m_Match != null)
       {
           return(System.Boolean) appdomain.Invoke(m_Match, instance,arg0);
        }
       else
       {
           return null;
       } 
}
bool m_bIsDefaultAttributeGot = false;
IMethod m_IsDefaultAttribute = null;
public  System.Boolean IsDefaultAttribute ()
{
   if(!m_bIsDefaultAttributeGot)
   {
       m_IsDefaultAttribute = instance.Type.GetMethod("IsDefaultAttribute",0);
       m_bIsDefaultAttributeGot = true;
   }
          if(m_IsDefaultAttribute != null)
       {
           return(System.Boolean) appdomain.Invoke(m_IsDefaultAttribute, instance,null);
        }
       else
       {
           return null;
       } 
}
}
}