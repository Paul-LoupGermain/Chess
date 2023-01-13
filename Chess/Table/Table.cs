namespace TableGame
{
    public class Table
    {
        #region private
        private string[,] _tabCases = new string[,] { { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8" }, { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8" }, { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8" }, { "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8" }, { "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8" }, { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8" }, { "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8" }, { "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8" } };
        private string[,] _tabPawn = new string[,] { { "R", "N", "B", "Q", "K", "B", "N", "R" }, { "P", "P", "P", "P", "P", "P", "P", "P" }, { " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " " }, { "p", "p", "p", "p", "p", "p", "p", "p" }, { "r", "n", "b", "q", "k", "b", "n", "r" } };
        #endregion private

        #region public
        public string[,] TabCase
        {
            get
            {
                return _tabCases;
            }

            set
            {
                _tabCases = value;    
            }
        }

        public string[,] TabPawn
        {
            get
            {
                return _tabPawn;
            }

            set
            {
                _tabPawn = value;
            }
        }
        #endregion public
    }
}