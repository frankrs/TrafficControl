//uScript Generated Code - Build 1.0.2628
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class car_movement : uScriptLogic
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
   System.Single local_2_System_Single = (float) 0.4;
   UnityEngine.GameObject local_3_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_3_UnityEngine_GameObject_previous = null;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_ControlGameObjectMove logic_uScriptAct_ControlGameObjectMove_uScriptAct_ControlGameObjectMove_0 = new uScriptAct_ControlGameObjectMove( );
   UnityEngine.GameObject logic_uScriptAct_ControlGameObjectMove_Target_0 = default(UnityEngine.GameObject);
   uScriptAct_ControlGameObjectMove.Direction logic_uScriptAct_ControlGameObjectMove_moveDirection_0 = uScriptAct_ControlGameObjectMove.Direction.Backward;
   System.Single logic_uScriptAct_ControlGameObjectMove_Speed_0 = (float) 0;
   System.Boolean logic_uScriptAct_ControlGameObjectMove_useLocal_0 = (bool) false;
   bool logic_uScriptAct_ControlGameObjectMove_Out_0 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_1 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_3_UnityEngine_GameObject = GameObject.Find( "car1" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_1 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_1 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_1 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_1.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_1;
                  component.OnLateUpdate += Instance_OnLateUpdate_1;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_1;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_1 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_1;
               component.OnLateUpdate -= Instance_OnLateUpdate_1;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_1;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_ControlGameObjectMove_uScriptAct_ControlGameObjectMove_0.SetParent(g);
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
      
   }
   
   public void OnDestroy()
   {
   }
   
   void Instance_OnUpdate_1(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_1( );
   }
   
   void Instance_OnLateUpdate_1(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_1( );
   }
   
   void Instance_OnFixedUpdate_1(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_1( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("51981610-2c1c-4a49-943b-2b9b458fda26", "Control GameObject (Move)", Relay_In_0)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_ControlGameObjectMove_Target_0 = local_3_UnityEngine_GameObject;
               
            }
            {
            }
            {
               logic_uScriptAct_ControlGameObjectMove_Speed_0 = local_2_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_ControlGameObjectMove_uScriptAct_ControlGameObjectMove_0.In(logic_uScriptAct_ControlGameObjectMove_Target_0, logic_uScriptAct_ControlGameObjectMove_moveDirection_0, logic_uScriptAct_ControlGameObjectMove_Speed_0, logic_uScriptAct_ControlGameObjectMove_useLocal_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript car_movement.uscript at Control GameObject (Move).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_1()
   {
      if (true == CheckDebugBreak("754b6cc2-70b8-405f-9ecd-67e0daa11d81", "Global Update", Relay_OnUpdate_1)) return; 
      Relay_In_0();
   }
   
   void Relay_OnLateUpdate_1()
   {
      if (true == CheckDebugBreak("754b6cc2-70b8-405f-9ecd-67e0daa11d81", "Global Update", Relay_OnLateUpdate_1)) return; 
   }
   
   void Relay_OnFixedUpdate_1()
   {
      if (true == CheckDebugBreak("754b6cc2-70b8-405f-9ecd-67e0daa11d81", "Global Update", Relay_OnFixedUpdate_1)) return; 
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "car_movement.uscript:2", local_2_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b9ffbe9b-d013-457c-8f8a-81cc8185dae3", local_2_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "car_movement.uscript:3", local_3_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7b0ad2c4-3958-4109-b554-8383592d063e", local_3_UnityEngine_GameObject);
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
