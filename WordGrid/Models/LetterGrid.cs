using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WordGrid.Models
{
    public class GridViewModel
    {
        public GridViewModel(int height, int width, IEnumerable<GridChar> chars)
        {
            foreach (var rowNum in Enumerable.Range(0, height))
            {
                Rows.Add(chars.Skip(rowNum * width).Take(width).ToList());
            }
        }

        public List<List<GridChar>> Rows { get; } = new List<List<GridChar>>();
    }
}
