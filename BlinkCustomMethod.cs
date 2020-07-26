using Exiled.API.Features;
using UnityEngine;

namespace BlinkFatigue
{
	internal static class BlinkCustomMethod
	{
		// Static fields needed to prevent multiple blinks.
		internal static float reworkSubstractTime = 0f;
		internal static bool someoneLooking = false;

		internal static void CustomBlinkingSequence(Scp173PlayerScript scpScript)
		{
			if (!scpScript.isServer || !scpScript.isLocalPlayer)
			{
				return;
			}

			Scp173PlayerScript._remainingTime -= Time.fixedDeltaTime;
			Scp173PlayerScript._blinkTimeRemaining -= Time.fixedDeltaTime;

			if (Scp173PlayerScript._remainingTime >= 0f)
			{
				return;
			}
			
			Scp173PlayerScript._blinkTimeRemaining = scpScript.blinkDuration_see + 0.4f;
			Scp173PlayerScript._remainingTime = Mathf.Max(BlinkFatigue.minReworkBlinkTime, Random.Range(BlinkFatigue.minBlinkTime, BlinkFatigue.maxBlinkTime) - reworkSubstractTime);

			if (someoneLooking)
			{
				float val = Random.Range(BlinkFatigue.reworkAddMin, BlinkFatigue.reworkAddMax);
				Log.Debug($"Adding {val} to {reworkSubstractTime}");
				reworkSubstractTime += val;
				// If SCP-173 is sick of your shit, this basically negates an infinite stacking of the blink fatigue ability
				if (reworkSubstractTime > BlinkFatigue.minBlinkTime)
				{
					reworkSubstractTime = BlinkFatigue.minBlinkTime;
				}
			}
			else
			{
				float val = Random.Range(BlinkFatigue.reworkAddMin, BlinkFatigue.reworkAddMax) * BlinkFatigue.decreaseRate;
				Log.Debug($"Substracting {val} to {reworkSubstractTime}");
				reworkSubstractTime -= val;
				if (reworkSubstractTime < 0f)
				{
					reworkSubstractTime = 0f;
				}
			}

			var array = PlayerManager.players;
			for (int i = 0; i < array.Count; i++)
			{
				var comp = array[i].GetComponent<Scp173PlayerScript>();
				if (comp != null)
				{
					comp.RpcBlinkTime();
				}
			}
		}
	}
}
