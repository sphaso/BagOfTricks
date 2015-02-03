using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Coursera.KerganGraph
{
    public class Karger
    {
        private Dictionary<int, List<int>> _graph;

        public Kergan(string sourceFile)
        {
            _graph = new Dictionary<int, List<int>>();
            //From Coursera file example. You need to populate the DS somehow
            using(var fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {
                        var split = line.Split('\t');
                        var head =  Int32.Parse(split[0]);
                        var body = new List<int>();
                        for(var i = 1; i < split.Length - 1; i++)
                        {
                            body.Add(int.Parse(split[i]));
                        }

                        _graph.Add(head, body);
                    }
                }
            }
        }

        private int Randomize(List<int> array)
        {
            var random = new Random();
            var index = random.Next(array.Count);
            return array[index];
        }

        public int Work()
        {
            while (_graph.Count > 2)
            {
                var node1 = Randomize(_graph.Keys.ToList());
                var node2 = Randomize(_graph[node1]);

                //Add to first node all nodes of the second node
                _graph[node2].ForEach(x => _graph[node1].Add(x));

                //Remove edge!
                _graph[node1].Remove(node2);

                //On each of the second node's links, redirect to node1
                for (var i = 0; i < _graph[node2].Count; i++)
                {
                    var key = _graph[node2][i];

                    _graph[key].Remove(node2);
                    _graph[key].Add(node1);
                    _graph[key] = _graph[key].ToList();
                }

                //Delete second node
                _graph.Remove(node2);

                //Delete self-referencing nodes
                _graph[node1] = _graph[node1].Where(x => x != node1)
                                             .ToList();
            }

            return _graph[_graph.Keys.First()].Count;
        }
    }
}
