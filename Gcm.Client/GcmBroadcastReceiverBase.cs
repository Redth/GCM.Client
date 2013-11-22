using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace Gcm.Client
{
	public abstract class GcmBroadcastReceiverBase<TIntentService> : BroadcastReceiver where TIntentService : GcmServiceBase
	{
		public override void OnReceive(Context context, Intent intent)
		{
			Logger.Debug("OnReceive: " + intent.Action);
			var className = context.PackageName + Constants.DEFAULT_INTENT_SERVICE_CLASS_NAME;

			Logger.Debug("GCM IntentService Class: " + className);

			GcmServiceBase.RunIntentInService(context, intent, typeof(TIntentService));
			SetResult(Result.Ok, null, null);
		}
	}
}