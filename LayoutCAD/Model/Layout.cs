using System;
using System.Collections.Generic;

namespace LayoutCAD.Model
{
    public class Layout
    {
        private readonly Func<Path> _pathFactory;

        private readonly List<Path> _paths = new List<Path>();
        public IEnumerable<Path> Paths => _paths;

        public Layout(Func<Path> pathFactory)
        {
            _pathFactory = pathFactory;
        }

        public void AddPath()
        {
            _paths.Add(_pathFactory());
        }
    }
}
