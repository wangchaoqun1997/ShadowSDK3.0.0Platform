using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShadowKit
{
	public class SCKeyboard : MonoBehaviour {

		public GameObject keyboard_num;
		public GameObject keyboard_symbol;
		public GameObject keyboard_enUp;
		public GameObject keyboard_enLow;

		private SCInputField input;
		private List<string> str;

		// Use this for initialization
		void Start () {
			gameObject.SetActive (false);
			str = new List<string> ();
		}

		public void show(SCInputField input, string value)
		{
			this.input = input;
			str = new List<string> ();
			for (int i = 0; i < value.Length; i++) {
				str.Add (value [i].ToString());
			}
			gameObject.SetActive (true);
			showEnLow ();
		}

		public void onClick(string value)
		{
			str.Add (value);
			setTextString ();
		}

		public void clear()
		{
			str = new List<string> ();
			setTextString ();
		}

		public void done()
		{
			str = new List<string> ();
			gameObject.SetActive (false);
		}

		public void del()
		{
			if (str.Count > 0) {
				str.RemoveAt (str.Count - 1);
				setTextString ();
			}
		}

		public void showNum()
		{
			keyboard_num.SetActive(true);
			keyboard_symbol.SetActive(false);
			keyboard_enUp.SetActive(false);
			keyboard_enLow.SetActive(false);
		}

		public void showSymbol()
		{
			keyboard_num.SetActive(false);
			keyboard_symbol.SetActive(true);
			keyboard_enUp.SetActive(false);
			keyboard_enLow.SetActive(false);
		}

		public void showEnUp()
		{
			keyboard_num.SetActive(false);
			keyboard_symbol.SetActive(false);
			keyboard_enUp.SetActive(true);
			keyboard_enLow.SetActive(false);
		}

		public void showEnLow()
		{
			keyboard_num.SetActive(false);
			keyboard_symbol.SetActive(false);
			keyboard_enUp.SetActive(false);
			keyboard_enLow.SetActive(true);
		}

		private void setTextString()
		{
			string text = "";
			for (int i = 0,l = str.Count; i < l; i++) {
				text += str [i];
			}
			input.text = text;
		}
	}
}

