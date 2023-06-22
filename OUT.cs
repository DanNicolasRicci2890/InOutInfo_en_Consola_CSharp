using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;

namespace PCD_INOUT_INFO
{
    public enum TypeLine
    {
		_SIMPLE,
		_DOUBLE,
		_LINEPOINTX,
		_NUMERAL,
		_ASTERIS,
		_MATRIX_SOLID,
		_MATRIX_SEMISOLID,
		_MATRIX_TRANSP,
		_MATRIX_DIAGON
	}
    public class OUT
    {
		public static void PrintLine(string frase, color Fore, color Back, int x, int y)
		{
			COLOR.ColorText(Fore, Back);
			Console.SetCursorPosition(x, y);
			Console.Write(frase);
		}
		public static void PrintLine(string fr1, string fr2, color Fore, color Back, int x, int y)
		{
			COLOR.ColorText(Fore, Back);
			Console.SetCursorPosition(x, y);
			Console.Write(fr1);
			Console.SetCursorPosition(x + fr1.Length, y);
			Console.Write(fr2);
		}
		public static void PrintLine(string[] fr, color[] fore, color[] back, int x, int y)
		{
			for (int i = 0; i < fr.Length; i++)
			{
				COLOR.ColorText(fore[i], back[i]);
				Console.SetCursorPosition(x, y);
				Console.Write(fr[i]);
				x += fr[i].Length;
			}
		}
		public static void TituloSubCaract(string fr, char caracter, bool space, color foret, color backt, color fores, color backs, int x, int y)
		{
			string text = "";
			for (int i = 0; i < fr.Length; i++)
			{
				text = ((fr[i] == ' ') ? ((!space) ? (text + caracter) : (text + " ")) : (text + caracter));
			}
			COLOR.ColorText(foret, backt);
			Console.SetCursorPosition(x, y);
			Console.Write(fr);
			COLOR.ColorText(fores, backs);
			Console.SetCursorPosition(x, y + 1);
			Console.Write(text);
		}
	}
}
