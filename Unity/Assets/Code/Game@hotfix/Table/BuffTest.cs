//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Game.Data
{
    using System;
    using System.Collections.Generic;
    using SQLite4Unity3d;
    
    
    [Serializable()]
    public class BuffTest
    {
        
        // buffid
      [PrimaryKey] 
        public int Id {get;set;}
        // buff类型
       public int BuffType {get;set;}
        // 冷却时间（回合）
       public int CD {get;set;}
        // 持续时间（回合）
       public int LifeTime {get;set;}
        // 描述
       public string Des {get;set;}
        // 参数列表，字符串类型
       public string[] Params_StrValue {get;set;}
        // 公式
       public List<string> Params_Expression {get;set;}
        // 参数列表，数值类型(固定数值)
       public int[] Params_NumValue {get;set;}
        // 显示特效
       public string Effect {get;set;}
    }
}
