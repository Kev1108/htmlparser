using System;
using System.Text;

namespace htmlparsing
{
    public class HtmlParser 
    {
        private StringBuilder _htmlFile;
        private int _fileLength;
        
        public HtmlParser(String htmlFile)
        {
            _fileLength = htmlFile.Length;
            _htmlFile = new StringBuilder(htmlFile);
        }

        public String DrawString()
        {
            StringBuilder buff = new StringBuilder();
            int i = 0, buffindex = 0, listFlag = 0, listindex = 0;
            buff.Capacity = _fileLength;          

            while(i < _fileLength)
            {
                if (_htmlFile[i] == '>')
                {
                    if (_htmlFile[i - 2] == 'l' && _htmlFile[i - 1] == 'i')  // Check if text belongs to a list tag.
                        listFlag = 1;

                    if (listFlag != 0 && _htmlFile[i - 2] == 'u' && _htmlFile[i - 1] == 'l')  // for unorder list add . as first character.
                    {
                        buff.Append('.');
                        buff.Append('\t');
                        buffindex += 2;
                    }
                        

                    if (listFlag != 0 && _htmlFile[i - 2] == 'o' && _htmlFile[i - 1] == 'l') // for orderded list add the corresponding number followed by a . and an space.
                    {
                        buff.Append(((char)listindex));
                        buff.Append('.');
                        buff.Append('\t');
                        listindex++;
                        buffindex += 3;
                    }

                    if (_htmlFile[i] == '\n')
                        i++;

                    i++;

                    while(i < _fileLength) // copy characters until a < character is found or eof is reached.
                    {
                        if (_htmlFile[i] == '<')
                            break;

                        buff.Append(_htmlFile[i]) ;
                        i++;
                        buffindex++;
                    }
                                       
                    if (buffindex > 0)
                    {
                        if ((_htmlFile[i + 2] == 'd' && _htmlFile[i + 3] == 'i') || _htmlFile[i + 2] == 'p' || ((_htmlFile[i + 2] == 'u' || _htmlFile[i + 2] == 'o') && _htmlFile[i + 3] == 'l')) // for block tags add a new line character at the end.
                        {
                            buff.Append('\n');
                           
                        }
                        else if (_htmlFile[i+2] == 'l' && _htmlFile[i+3] == 'i') // for list tags reset the order count to 0 and exit the list.
                        {
                            buff.Append('\n');
                            listFlag = 0;
                            listindex = 0;
                        }
                        else
                        {
                            buff.Append('\t'); // for line elements just add and space.
                        }
                    }
                }

                i++;
            }

            return buff.ToString();
        }

        
    }
}

