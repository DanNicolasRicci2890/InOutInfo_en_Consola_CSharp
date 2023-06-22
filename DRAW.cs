using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;

namespace PCD_INOUT_INFO
{
    public class DRAW
    {
		public static void CuadradoCaracterLine(char caracter, color bc, color tc, int width, int heingth, int x, int y)
		{
			string text = "";
			for (int i = 0; i < heingth + 2; i++)
			{
				for (int j = 0; j < width + 2; j++)
				{
					text = ((i != 0 && i != heingth + 1) ? ((j != 0 && j != width + 1) ? (text + ' ') : (text + caracter)) : (text + caracter));
				}
				OUT.PrintLine(text, tc, bc, x, y + i);
				text = "";
			}
		}
		public static void CuadradoCaracterSolid(char caracter, color bc, color tc, int width, int heingth, int x, int y)
		{
			string text = "";
			for (int i = 0; i < heingth + 2; i++)
			{
				for (int j = 0; j < width + 2; j++)
				{
					text += caracter;
				}
				OUT.PrintLine(text, tc, bc, x, y + i);
				text = "";
			}
		}
		public static void CuadradoLineDouble(color bc, color tc, int width, int heingth, int x, int y)
		{
			string text = "";
			for (int i = 0; i < heingth + 2; i++)
			{
				for (int j = 0; j < width + 2; j++)
				{
					char c = ' ';
					if (i == 0 && j == 0)
					{
						c = '╔';
					}
					else if (i == 0 && j == width + 1)
					{
						c = '╗';
					}
					else if (i == heingth + 1 && j == 0)
					{
						c = '╚';
					}
					else if (i == heingth + 1 && j == width + 1)
					{
						c = '╝';
					}
					else if (j > 0 && j < width + 1 && (i == 0 || i == heingth + 1))
					{
						c = '═';
					}
					else if ((j == 0 || j == width + 1) && i > 0 && i < heingth + 1)
					{
						c = '║';
					}
					text += c;
				}
				OUT.PrintLine(text, tc, bc, x, y + i);
				text = "";
			}
		}
		public static void CuadradoSolid(color bc, int width, int heingth, int x, int y)
		{
			string text = "";
			for (int i = 0; i < heingth + 2; i++)
			{
				for (int j = 0; j < width + 2; j++)
				{
					text += " ";
				}
				OUT.PrintLine(text, color.none, bc, x, y + i);
				text = "";
			}
		}
		public static void TablaLine(TypeLine cond, color bc, color tc, int[] columnas, int[] filas, int x, int y)
		{
			int num = columnas.Length;
			int num2 = filas.Length;
			int num3 = -1;
			int num4 = 0;
			for (int i = 0; i < num2; i++)
			{
				int num5 = filas[i];
				for (int j = 0; j < num5 + 1; j++)
				{
					string text = "";
					for (int k = 0; k < num; k++)
					{
						int num6 = columnas[k];
						for (int l = 0; l < num6 + 1; l++)
						{
							num3 = SeleccionCondicion(i, j, k, l, num6, num5, num2, num, filas, columnas);
							text += SelectorCaracter(cond, num3);
						}
					}
					OUT.PrintLine(text, tc, bc, x, y + num4);
					num4++;
				}
			}
		}
		private static char SelectorCaracter(TypeLine cond, int condicion)
		{
			char result = ' ';
			if (condicion != -1)
			{
				switch (cond)
				{
					case TypeLine._DOUBLE:
						switch (condicion)
						{
							case 0:
								result = '╔';
								break;
							case 1:
								result = '╗';
								break;
							case 3:
								result = '╚';
								break;
							case 4:
								result = '╝';
								break;
							case 5:
								result = '╦';
								break;
							case 6:
								result = '╠';
								break;
							case 7:
								result = '╣';
								break;
							case 8:
								result = '╩';
								break;
							case 9:
								result = '╬';
								break;
							case 10:
								result = '═';
								break;
							case 11:
								result = '║';
								break;
						}
						break;
					case TypeLine._SIMPLE:
						switch (condicion)
						{
							case 0:
								result = '┌';
								break;
							case 1:
								result = '┐';
								break;
							case 3:
								result = '└';
								break;
							case 4:
								result = '┘';
								break;
							case 5:
								result = '┬';
								break;
							case 6:
								result = '├';
								break;
							case 7:
								result = '┤';
								break;
							case 8:
								result = '┴';
								break;
							case 9:
								result = '┼';
								break;
							case 10:
								result = '─';
								break;
							case 11:
								result = '│';
								break;
						}
						break;
					case TypeLine._LINEPOINTX:
						if (condicion >= 0 && condicion <= 8)
						{
							result = '*';
						}
						if (condicion == 9)
						{
							result = '+';
						}
						if (condicion == 10)
						{
							result = '─';
						}
						if (condicion == 11)
						{
							result = '│';
						}
						break;
					case TypeLine._NUMERAL:
						result = '#';
						break;
					case TypeLine._ASTERIS:
						result = '*';
						break;
					case TypeLine._MATRIX_SOLID:
						result = '█';
						break;
					case TypeLine._MATRIX_SEMISOLID:
						result = '▓';
						break;
					case TypeLine._MATRIX_TRANSP:
						result = '▒';
						break;
					case TypeLine._MATRIX_DIAGON:
						result = '░';
						break;
				}
			}
			else
			{
				result = ' ';
			}
			return result;
		}
		private static int SeleccionCondicion(int t, int q, int j, int i, int t_columna, int t_fila, int tope_filas, int tope_columnas, int[] filas, int[] columnas)
		{
			int result = -1;
			if (i == 0 && j == 0 && q == 0 && t == 0)
			{
				result = 0;
			}
			else if (i == t_columna && j == tope_columnas - 1 && q == 0 && t == 0)
			{
				result = 1;
			}
			else if (i == 0 && j == 0 && q == t_fila && t == tope_filas - 1)
			{
				result = 3;
			}
			else if (i == t_columna && j == tope_columnas - 1 && q == t_fila && t == tope_filas - 1)
			{
				result = 4;
			}
			else if (i == 0 && j > 0 && j < tope_columnas && q == 0 && t == 0)
			{
				result = 5;
			}
			else if (i == 0 && j == 0 && q == 0 && t > 0 && t < tope_filas)
			{
				result = 6;
			}
			else if (i == t_columna && j == tope_columnas - 1 && q == 0 && t > 0 && t < tope_filas)
			{
				result = 7;
			}
			else if (i == 0 && j > 0 && j < tope_columnas && q == t_fila && t == tope_filas - 1)
			{
				result = 8;
			}
			else if (i == 0 && j > 0 && j < tope_columnas && q == 0 && t > 0 && t < tope_filas)
			{
				result = 9;
			}
			else if (i > 0 && i < t_columna + 1 && q == 0)
			{
				result = 10;
			}
			else if (i > 0 && i < t_columna + 1 && q == t_fila && t == tope_filas - 1)
			{
				result = 10;
			}
			else if ((i == 0 && q > 0 && q < t_fila + 1) || (i == t_columna && q > 0 && q < t_fila + 1 && j == tope_columnas - 1))
			{
				result = 11;
			}
			return result;
		}

	}
}
