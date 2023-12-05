using Algorithms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_2
{
    class MazeCellViewModel : INotifyPropertyChanged
    {
        public MazeCellViewModel(string CellColour)
        {
            colour = CellColour;
        }

        private string colour;
        public string Colour {
            get { return colour; }
            set { colour = value; OnPropertyChanged(nameof(colour)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class MainViewModel : INotifyPropertyChanged 
    {
        
        public MainViewModel(int width, int height)
        {
            mazeWidth = width;
            mazeHeight = height;
            mazeCells = new ObservableCollection<MazeCellViewModel>();
        }

        private ObservableCollection<MazeCellViewModel> mazeCells;
        public ObservableCollection<MazeCellViewModel> MazeCells {
            get { return mazeCells; }
            set { mazeCells = value; OnPropertyChanged(nameof(mazeCells)); }
        }

        private int mazeWidth;
        public int MazeWidth {
            get { return mazeWidth; }
            set { mazeWidth = value; OnPropertyChanged(nameof(mazeWidth)); }
        }

        private int mazeHeight;
        public int MazeHeight {
            get { return mazeHeight; } 
            set { mazeHeight = value; OnPropertyChanged(nameof(mazeHeight)); } 
        }

        public void Initialize() {
            Maze maze = new DepthFirstGeneration((int)mazeWidth, (int)mazeHeight);
            maze.InitMaze();
            maze.BuildMaze(maze.MazeCoordinates[1, 1]);

            for (int i = 0; i < maze.MazeWalls.GetLength(0); i++) {
                for (int j = 0; j < maze.MazeWalls.GetLength(1); j++) {
                    if (maze.MazeWalls[j, i])
                        mazeCells.Add(new MazeCellViewModel("Black"));
                    else
                        mazeCells.Add(new MazeCellViewModel("White"));
                }
            }
            Debug.WriteLine(mazeCells.Count);
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
