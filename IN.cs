using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;

namespace PCD_INOUT_INFO
{
	public enum INCond
	{
		_SHIFT,
		_CTRL,
		_ALT,
		_ENTER,
		_BACKSPACE,
		_SPACEBAR,
		_TAB,
		_ARROWS,
		_FUNCTIONF,
		_OEMSKEY,
		_OEMARITM,
		_PADARITM,
		_MINIPAD,
		_ESCAPE,
		_LETTER,
		_NUMERS,
		_NUMPADS
	}
	public class IN
    {
		private int _Condicion;
		public IN()
		{
			_Condicion = 0;
		}
		public string InputMode()
		{
			Console.TreatControlCAsInput = true;
			ConsoleKeyInfo tecla = Console.ReadKey(intercept: false);
			string text = "";
			text += VERIFMODIFICS(tecla);
			text += KEYCONDITIONAL(tecla);
			text += ARROWS(tecla);
			text += FUNCTIONF(tecla);
			text += OEMSKEY(tecla);
			text += OEMARITM(tecla);
			text += PADDARITM(tecla);
			text += MINIPAD(tecla);
			text += ESCAPE(tecla);
			text += LETTERS(tecla);
			text += NUMERS(tecla);
			return text + NUMERSPADS(tecla);
		}
		public void SetResetIN(INCond cot)
		{
			if (_Condicion >> (int)cot == 1)
			{
				this._Condicion &= ~(1 << (int)cot);
			}
		}
		public void SetCondIN(INCond cot) => this._Condicion |= 1 << (int)cot;		
		private string VERIFMODIFICS(ConsoleKeyInfo tecla)
		{
			string text = "";
			if (VerifPosCond(INCond._SHIFT) && tecla.Modifiers == ConsoleModifiers.Shift)
			{
				text += "SHIFT + ";
			}
			if (VerifPosCond(INCond._CTRL) && tecla.Modifiers == ConsoleModifiers.Control)
			{
				text += "CTRL + ";
			}
			if (VerifPosCond(INCond._SHIFT) && VerifPosCond(INCond._CTRL) && tecla.Modifiers == (ConsoleModifiers.Shift | ConsoleModifiers.Control))
			{
				text += "CTRL + SHIFT + ";
			}
			if (VerifPosCond(INCond._SHIFT) && VerifPosCond(INCond._ALT) && tecla.Modifiers == (ConsoleModifiers.Alt | ConsoleModifiers.Shift))
			{
				text += "SHIFT + ALT + ";
			}
			if (VerifPosCond(INCond._CTRL) && VerifPosCond(INCond._ALT) && tecla.Modifiers == (ConsoleModifiers.Alt | ConsoleModifiers.Control))
			{
				text += "CTRL + ALT + ";
			}
			if (VerifPosCond(INCond._CTRL) && VerifPosCond(INCond._SHIFT) && VerifPosCond(INCond._ALT) && tecla.Modifiers == (ConsoleModifiers.Alt | ConsoleModifiers.Shift | ConsoleModifiers.Control))
			{
				text += "CTRL + SHIFT + ALT + ";
			}
			return text;
		}
		private string PADDARITM(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._PADARITM))
			{
				switch (tecla.Key)
				{
					case ConsoleKey.Add: result = "P+"; break;
					case ConsoleKey.Subtract: result = "P-"; break;
					case ConsoleKey.Multiply: result = "P*"; break;
					case ConsoleKey.Divide: result = "P/"; break;
				}
			}
			return result;
		}
		private string OEMSKEY(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._OEMSKEY))
			{
				switch (tecla.Key)
				{
					case ConsoleKey.Oem1: result = "Oem1"; break;
					case ConsoleKey.Oem2: result = "Oem2"; break;
					case ConsoleKey.Oem4: result = "Oem4"; break;
					case ConsoleKey.Oem5: result = "Oem5"; break;
					case ConsoleKey.Oem6: result = "Oem6"; break;
					case ConsoleKey.Oem7: result = "Oem7"; break;
					case ConsoleKey.Oem102: result = "Oem102"; break;
				}
			}
			return result;
		}
		private string OEMARITM(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._OEMARITM))
			{
				switch (tecla.Key)
				{
					case ConsoleKey.OemPlus: result = "Oem+"; break;
					case ConsoleKey.OemMinus: result = "Oem-"; break; 
					case ConsoleKey.OemComma: result = "OemC"; break;
					case ConsoleKey.OemPeriod: result = "OemP"; break;
					case ConsoleKey.OemClear: result = "OemClear"; break;
				}
			}
			return result;
		}

		private string NUMERSPADS(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._NUMPADS))
			{
				switch (tecla.Key)
				{
					case ConsoleKey.NumPad0: result = "NUMPAD_0"; break;
					case ConsoleKey.NumPad1: result = "NUMPAD_1"; break;
					case ConsoleKey.NumPad2: result = "NUMPAD_2"; break;
					case ConsoleKey.NumPad3: result = "NUMPAD_3"; break;
					case ConsoleKey.NumPad4: result = "NUMPAD_4"; break;
					case ConsoleKey.NumPad5: result = "NUMPAD_5"; break;
					case ConsoleKey.NumPad6: result = "NUMPAD_6"; break;
					case ConsoleKey.NumPad7: result = "NUMPAD_7"; break;
					case ConsoleKey.NumPad8: result = "NUMPAD_8"; break;
					case ConsoleKey.NumPad9: result = "NUMPAD_9"; break;
				}
			}
			return result;
		}
		private string NUMERS(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._NUMERS))
			{
				switch (tecla.Key)
				{
					case ConsoleKey.D0: result = "0"; break;
					case ConsoleKey.D1: result = "1"; break;
					case ConsoleKey.D2: result = "2"; break;
					case ConsoleKey.D3: result = "3"; break;
					case ConsoleKey.D4: result = "4"; break;
					case ConsoleKey.D5: result = "5"; break;
					case ConsoleKey.D6: result = "6"; break;
					case ConsoleKey.D7: result = "7"; break;
					case ConsoleKey.D8: result = "8"; break;
					case ConsoleKey.D9: result = "9"; break;
				}
			}
			return result;
		}
		private string MINIPAD(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._MINIPAD))
			{
				switch (tecla.Key)
				{
					case ConsoleKey.Insert: result = "INS"; break;
					case ConsoleKey.Delete: result = "DEL"; break;
					case ConsoleKey.Home: result = "HOME"; break;
					case ConsoleKey.End: result = "END"; break;
					case ConsoleKey.PageUp: result = "PUP"; break;
					case ConsoleKey.PageDown: result = "PDOWN"; break;
				}
			}
			return result;
		}
		private string LETTERS(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._LETTER))
			{
				switch (tecla.Key)
				{
					case ConsoleKey.A: result = "A"; break;
					case ConsoleKey.B: result = "B"; break;
					case ConsoleKey.C: result = "C"; break;
					case ConsoleKey.D: result = "D"; break;
					case ConsoleKey.E: result = "E"; break;
					case ConsoleKey.F: result = "F"; break;
					case ConsoleKey.G: result = "G"; break;
					case ConsoleKey.H: result = "H"; break;
					case ConsoleKey.I: result = "I"; break;
					case ConsoleKey.J: result = "J"; break;
					case ConsoleKey.K: result = "K"; break;
					case ConsoleKey.L: result = "L"; break;
					case ConsoleKey.M: result = "M"; break;
					case ConsoleKey.N: result = "N"; break;
					case ConsoleKey.Oem3: result = "Ñ"; break;
					case ConsoleKey.O: result = "O"; break;
					case ConsoleKey.P: result = "P"; break;
					case ConsoleKey.Q: result = "Q"; break;
					case ConsoleKey.R: result = "R"; break;
					case ConsoleKey.S: result = "S"; break;
					case ConsoleKey.T: result = "T"; break;
					case ConsoleKey.U: result = "U"; break;
					case ConsoleKey.V: result = "V"; break;
					case ConsoleKey.W: result = "W"; break;
					case ConsoleKey.X: result = "X"; break;
					case ConsoleKey.Y: result = "Y"; break;
					case ConsoleKey.Z: result = "Z"; break;
				}
			}
			return result;
		}
		private string KEYCONDITIONAL(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._BACKSPACE) && tecla.Key == ConsoleKey.Backspace)
			{
				result = "BACKSPACE";
			}
			if (VerifPosCond(INCond._ENTER) && tecla.Key == ConsoleKey.Enter)
			{
				result = "ENTER";
			}
			if (VerifPosCond(INCond._SPACEBAR) && tecla.Key == ConsoleKey.Spacebar)
			{
				result = "SPACEBAR";
			}
			if (VerifPosCond(INCond._TAB) && tecla.Key == ConsoleKey.Tab)
			{
				result = "TAB";
			}
			return result;
		}
		private string FUNCTIONF(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._FUNCTIONF))
			{
				switch (tecla.Key)
				{
					case ConsoleKey.F1: result = "F1"; break;
					case ConsoleKey.F2: result = "F2"; break;
					case ConsoleKey.F3: result = "F3"; break;
					case ConsoleKey.F4: result = "F4"; break;
					case ConsoleKey.F5: result = "F5"; break;
					case ConsoleKey.F6: result = "F6"; break;
					case ConsoleKey.F7: result = "F7"; break;
					case ConsoleKey.F8: result = "F8"; break;
					case ConsoleKey.F9: result = "F9"; break;
					case ConsoleKey.F10: result = "F10"; break;
					case ConsoleKey.F11: result = "F11"; break;
					case ConsoleKey.F12: result = "F12"; break;
					case ConsoleKey.F13: result = "F13"; break;
					case ConsoleKey.F14: result = "F14"; break;
					case ConsoleKey.F15: result = "F15"; break;
					case ConsoleKey.F16: result = "F16"; break;
					case ConsoleKey.F17: result = "F17"; break;
					case ConsoleKey.F18: result = "F18"; break;
					case ConsoleKey.F19: result = "F19"; break;
					case ConsoleKey.F20: result = "F20"; break;
					case ConsoleKey.F21: result = "F21"; break;
					case ConsoleKey.F22: result = "F22"; break;
					case ConsoleKey.F23: result = "F23"; break;
					case ConsoleKey.F24: result = "F24"; break;
				}
			}
			return result;
		}
		private string ESCAPE(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._ESCAPE))
			{
				ConsoleKey key = tecla.Key;
				ConsoleKey consoleKey = key;
				if (consoleKey == ConsoleKey.Escape)
				{
					result = "ESC";
				}
			}
			return result;
		}
		private string ARROWS(ConsoleKeyInfo tecla)
		{
			string result = "";
			if (VerifPosCond(INCond._ARROWS))
			{
				switch (tecla.Key)
				{
					case ConsoleKey.UpArrow: result = "UPARROW"; break;
					case ConsoleKey.DownArrow: result = "DOWNARROW"; break;
					case ConsoleKey.LeftArrow: result = "LEFTARROW"; break;
					case ConsoleKey.RightArrow: result = "RIGHTARROW"; break;
				}
			}
			return result;
		}
		private bool VerifPosCond(INCond state) => ((_Condicion >> (int)state) & 1) == 1;
	}
}
