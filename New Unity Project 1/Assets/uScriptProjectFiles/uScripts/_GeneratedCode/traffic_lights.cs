//uScript Generated Code - Build 1.0.2628
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class traffic_lights : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   uScript_GUI thisScriptsOnGuiListener = null; 
   bool m_RegisteredForEvents = false;
   delegate void ContinueExecution();
   ContinueExecution m_ContinueExecution;
   bool m_Breakpoint = false;
   const int MaxRelayCallCount = 1000;
   int relayCallCount = 0;
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_2 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_1 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_1 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_1 = (float) 0;
   bool logic_uScriptAct_Destroy_Out_1 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_1 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_1 = false;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == owner_Connection_2 || false == m_RegisteredForEvents )
      {
         owner_Connection_2 = parentGameObject;
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_0 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_0 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_0 )
         {
            {
               uScript_Mouse component = event_UnityEngine_GameObject_Instance_0.GetComponent<uScript_Mouse>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_0.AddComponent<uScript_Mouse>();
               }
               if ( null != component )
               {
                  component.OnEnter += Instance_OnEnter_0;
                  component.OnOver += Instance_OnOver_0;
                  component.OnExit += Instance_OnExit_0;
                  component.OnDown += Instance_OnDown_0;
                  component.OnUp += Instance_OnUp_0;
                  component.OnDrag += Instance_OnDrag_0;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_0 )
      {
         {
            uScript_Mouse component = event_UnityEngine_GameObject_Instance_0.GetComponent<uScript_Mouse>();
            if ( null != component )
            {
               component.OnEnter -= Instance_OnEnter_0;
               component.OnOver -= Instance_OnOver_0;
               component.OnExit -= Instance_OnExit_0;
               component.OnDown -= Instance_OnDown_0;
               component.OnUp -= Instance_OnUp_0;
               component.OnDrag -= Instance_OnDrag_0;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Destroy_uScriptAct_Destroy_1.SetParent(g);
   }
   public void Awake()
   {
      
   }
   
   public void Start()
   {
      SyncUnityHooks( );
      m_RegisteredForEvents = true;
      
   }
   
   public void OnEnable()
   {
      RegisterForUnityHooks( );
      m_RegisteredForEvents = true;
   }
   
   public void OnDisable()
   {
      UnregisterEventListeners( );
      m_RegisteredForEvents = false;
   }
   
   public void Update()
   {
      //reset each Update, and increments each method call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      if ( null != m_ContinueExecution )
      {
         ContinueExecution continueEx = m_ContinueExecution;
         m_ContinueExecution = null;
         m_Breakpoint = false;
         continueEx( );
         return;
      }
      UpdateEditorValues( );
      
      //other scripts might have added GameObjects with event scripts
      //so we need to verify all our event listeners are registered
      SyncEventListeners( );
      
      if (true == logic_uScriptAct_Destroy_WaitOneTick_1)
      {
         Relay_WaitOneTick_1();
      }
   }
   
   public void OnDestroy()
   {
   }
   
   void Instance_OnEnter_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnEnter_0( );
   }
   
   void Instance_OnOver_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnOver_0( );
   }
   
   void Instance_OnExit_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnExit_0( );
   }
   
   void Instance_OnDown_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDown_0( );
   }
   
   void Instance_OnUp_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUp_0( );
   }
   
   void Instance_OnDrag_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDrag_0( );
   }
   
   void Relay_OnEnter_0()
   {
      if (true == CheckDebugBreak("bc3a5dd8-a6ea-4d70-9980-60c2162dd0ef", "Mouse Cursor Events", Relay_OnEnter_0)) return; 
   }
   
   void Relay_OnOver_0()
   {
      if (true == CheckDebugBreak("bc3a5dd8-a6ea-4d70-9980-60c2162dd0ef", "Mouse Cursor Events", Relay_OnOver_0)) return; 
   }
   
   void Relay_OnExit_0()
   {
      if (true == CheckDebugBreak("bc3a5dd8-a6ea-4d70-9980-60c2162dd0ef", "Mouse Cursor Events", Relay_OnExit_0)) return; 
   }
   
   void Relay_OnDown_0()
   {
      if (true == CheckDebugBreak("bc3a5dd8-a6ea-4d70-9980-60c2162dd0ef", "Mouse Cursor Events", Relay_OnDown_0)) return; 
      Relay_In_1();
   }
   
   void Relay_OnUp_0()
   {
      if (true == CheckDebugBreak("bc3a5dd8-a6ea-4d70-9980-60c2162dd0ef", "Mouse Cursor Events", Relay_OnUp_0)) return; 
   }
   
   void Relay_OnDrag_0()
   {
      if (true == CheckDebugBreak("bc3a5dd8-a6ea-4d70-9980-60c2162dd0ef", "Mouse Cursor Events", Relay_OnDrag_0)) return; 
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6bd3c795-bc0f-417f-b603-932b53726daf", "Destroy", Relay_In_1)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.Add((UnityEngine.GameObject)owner_Connection_2);
               logic_uScriptAct_Destroy_Target_1 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_uScriptAct_Destroy_1.In(logic_uScriptAct_Destroy_Target_1, logic_uScriptAct_Destroy_DelayTime_1);
         logic_uScriptAct_Destroy_WaitOneTick_1 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript traffic_lights.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_1( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.Add((UnityEngine.GameObject)owner_Connection_2);
               logic_uScriptAct_Destroy_Target_1 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_WaitOneTick_1 = logic_uScriptAct_Destroy_uScriptAct_Destroy_1.WaitOneTick();
         if ( true == logic_uScriptAct_Destroy_WaitOneTick_1 )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript traffic_lights.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   private void UpdateEditorValues( )
   {
   }
   bool CheckDebugBreak(string guid, string name, ContinueExecution method)
   {
      if (true == m_Breakpoint) return true;
      
      if (true == uScript_MasterComponent.LatestMasterComponent.HasBreakpoint(guid))
      {
         if (uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint == guid)
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = "";
         }
         else
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = guid;
            UpdateEditorValues( );
            UnityEngine.Debug.Log("uScript BREAK Node:" + name + " ((Time: " + Time.time + "");
            UnityEngine.Debug.Break();
            #if (!UNITY_FLASH)
            m_ContinueExecution = new ContinueExecution(method);
            #endif
            m_Breakpoint = true;
            return true;
         }
      }
      return false;
   }
}
