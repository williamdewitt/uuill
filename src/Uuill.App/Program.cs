const int pageHeight = 10;
const int pageWidth = 10;

Console.Clear();

var lin = 0;
var col = 0;
var page = new char[pageHeight, pageWidth];
Array.Clear(page);

do
{
  var key = Console.ReadKey(true);

  if (IsArrowKey(key))
  {
    MoveCursor(key);
  }
  else
  {
    PrintKey(key.KeyChar);
  }
}
while (lin < pageHeight);

void MoveCursor(ConsoleKeyInfo key)
{
  if (key.Key == ConsoleKey.LeftArrow)
  {
    if (lin == 0 && col == 0)
    {
      PrintCursor();
      return;
    }

    if (col == 0 && lin > 0)
    {
      lin--;
      col = pageWidth;
    }
    else if (col > 0)
    {
      col--;
    }

    PrintCursor();
    Console.SetCursorPosition(col, lin);
  }
}

bool IsArrowKey(ConsoleKeyInfo key)
{
  // LeftArrow = 37
  return key.Key == ConsoleKey.LeftArrow;
}

Console.WriteLine("Thanks for playing.");
SaveToFile();

void SaveToFile(string fileName = "temp.txt")
{
  for(int i = 0; i < pageHeight; i++)
  {
    for(int j = 0; j < pageWidth; j++)
    {
      File.AppendAllText($"./src/Uuill.App/{fileName}", page[i,j].ToString());
    }
  }
}

void PrintKey(char key)
{
  page[lin, col] = key;
  Console.Write(key);

  col++;

  if (col == pageWidth)
  {
    col = 0;
    Console.SetCursorPosition(col, lin);
    // Console.WriteLine();
    lin++;
  }

  PrintCursor();
}

void PrintCursor()
{
  Console.SetCursorPosition(0, pageHeight + 2);
  Console.Write($"line:   ; column   ");
  Console.SetCursorPosition(0, pageHeight + 2);
  Console.Write($"line: {lin}; column {col}");
  Console.SetCursorPosition(col, lin);
}