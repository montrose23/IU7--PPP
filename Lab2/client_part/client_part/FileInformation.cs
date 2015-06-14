using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace client_part
{
    public class FileInformation
    {
        public FileInformation(string path)
        {
            if (File.Exists(path))
                _path = path;
            _extension = get_extension();
            _name = get_file_name();
            if (_extension != null && _name != null)
                get_data(path);

            compose();
        }

        private string get_extension()
        {            
            return File.Exists(_path) ? Path.GetExtension(_path) : null;
        }

        private string get_file_name()
        {
            return File.Exists(_path) ? Path.GetFileNameWithoutExtension(_path) : null;
        }

        private void get_data(string path)
        {
            _data = File.ReadAllBytes(path);
            _size = _data.Length;
        }

        private void compose()
        {
            _for_send = "";
            _for_send += "<file>";
            _for_send += "<name>";
            _for_send += _name;
            _for_send += "</name>";
            _for_send += "<extension>";
            _for_send += _extension;
            _for_send += "</extension>";
            _for_send += "<data>";
            _for_send += Encoding.ASCII.GetString(_data, 0, _data.Length);
            _for_send += "</data>";
            _for_send += "</file>";
        }

        public string for_send
        {
            get
            {
                return _for_send;
            }
        }

        private string _path;
        private string _name;
        private string _extension;
        private int _size;
        private byte[] _data;
        private string _for_send;
    }
}
