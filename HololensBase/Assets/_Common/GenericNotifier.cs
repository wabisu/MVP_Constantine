using System;
using UnityEngine;

namespace GenericNotifierNs
{

    /// <summary>
    /// In fact, TEnum is enum
    /// </summary>
    /// <typeparam name="TNotificationId">
    /// Basically, the type parameter is enumeration. System.Enum can't be used directly as constraint, but
    /// the set of constraints can corresponds to https://msdn.microsoft.com/en-us/library/system.enum(v=vs.90).aspx
    /// public abstract class Enum : ValueType, IComparable, IFormattable, IConvertible
    /// </typeparam>
    public class GenericNotifier<TNotificationId, TParam> 
        where TNotificationId: struct,
        IComparable, IFormattable, IConvertible
 
    {
   

        #region Notification events
        // Event will never null so never checks for Null
        // As supposed the usage with  multi-threading environment (caused of architecture of parse.com, sockets etc), 
        // http://blogs.msdn.com/b/ericlippert/archive/2009/04/29/events-and-races.aspx is necessary

        event Action<TNotificationId, TParam> ExtNotificationEvent = delegate { };
        //public static event NotificationEventHandlerExt ExtNotificationEvent = (id, paramType, param) => _DS.Log(string.Format("Raised extended notification {0} type {1}", id.ToString (), paramType.ToString ()));



        public void Subscribe(Action<TNotificationId, TParam> newHandler)
        {
            ExtNotificationEvent += newHandler;
        }



        public void UnSubscribe(Action<TNotificationId, TParam> handler)
        {
            ExtNotificationEvent -= handler;
        }


        public  void Notify(TNotificationId id)
        {

            Notify(id, default(TParam));
        }


        /// <summary>
        /// Notify all subscribers, passing some object with data to them
        /// </summary>
        /// <param name="id">Notification id</param>
        /// <param name="paramType">Type of object stored in param</param>
        /// <param name="param">Object stored in param as System.Object</param>
        public void Notify(TNotificationId id, TParam param)
        {

           // Debug.Log(string.Format("Notification:{0}  type {1} value '{2}' ",id, typeof(TParam), param) );
            var eventDoublicate = ExtNotificationEvent;
            if (eventDoublicate != null)
                eventDoublicate(id,  param);
        }
        #endregion

    }


}