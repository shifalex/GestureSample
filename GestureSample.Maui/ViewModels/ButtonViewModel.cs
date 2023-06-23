
using GestureSample.Maui.ViewModels;
using System.Collections;
using System.Windows.Input;

namespace GestureSample.ViewModels
{
    public partial class ButtonViewModel : CustomEventArgsViewModel
    {
        //private readonly bool ASSERT = false;
        private readonly int NAN = 0;

        private int _addent1 = 0;

        private int _addent2 = 0;

        private int _sum = 5;

        public string SAddent1
        {
            get
            {
                if (_addent1 == NAN) return "0";
                return _addent1.ToString();
            }
            set
            {
                int _addent22;
                try { _addent22 = Int32.Parse(value); } catch { _addent22 = NAN; }
                SetProperty(ref _addent1, _addent22);
                //OnPropertyChanged(nameof(Addent1)); OnPropertyChanged(nameof(TrueStatement));
            }
        }
        public string SAddent2
        {
            get
            {
                if (_addent2 == NAN) return "0";
                return _addent2.ToString();
            }
            set
            {
                int _addent22;
                try { _addent22 = Int32.Parse(value); } catch { _addent22 = NAN; }
                SetProperty(ref _addent2, _addent22);
                //OnPropertyChanged(nameof(Addent2)); OnPropertyChanged(nameof(TrueStatement));
            }
        }
        public string SSum
        {
            get
            {
                if (_sum == NAN) return "0";
                return _sum.ToString();
            }
            set
            {
                int _sum2;
                try { _sum2 = Int32.Parse(value); } catch { _sum2 = NAN; }
                SetProperty(ref _sum, _sum2);
                //OnPropertyChanged(nameof(Sum)); OnPropertyChanged(nameof(TrueStatement));
            }
        }

        private bool test=true;
            public string STest
        {
            get { if(test) return "true"; return "false"; }
            set { SetProperty(ref test, !test); }

        }

        public int Addent1
        {
            get { return _addent1; }
            set { SetProperty(ref _addent1, value); }
        }



        public int Addent2
        {
            get { return _addent2; }
            set { SetProperty(ref _addent2, value); }
        }

        private Color _bgColor = Color.FromArgb("808080");
        public Color Color
        {
            get
            {
                return _bgColor;
            }
            set
            {
                SetProperty(ref _bgColor, Color.FromArgb("808080"));
                //_bgColor=value;
                NotifyPropertyChanged(nameof(Color));
            }
        }

        private bool _isFirstGuess = true;
        public bool isNotFirstGuess
        {
            get { return !_isFirstGuess; }
        }
        private bool _isEnabledTotal = true;
        public bool IsEnabledTotal {
        get{ return _isEnabledTotal; }

            set { SetProperty(ref _isEnabledTotal, value); }
        }
        public String TrueStatement
        {
            get
            {



                if (_isFirstGuess) { 
                    return "PLEASE ANSWER"; 
                }

                //else if (_addent1 > _maxAddent || _addent1 < _minAddent || _addent2 > _maxAddent || _addent2 < _minAddent || _sum > _maxSum || _sum < _minAddent) return "wrong input!";
                else if (_sum == _addent1 + _addent2)
                {
                    if (_requireNewAddents)
                    {
                        foreach (PPWObject ppw in _allHistory)
                            if (ppw.Sum == _sum && ppw.Addent1 == _addent1)
                            {

                                //Addent1 = NAN; Addent2 = NAN;
                                return "Find NEW combination";
                            }

                    }
                    //OnPropertyChanged(nameof(SumEnabled)); OnPropertyChanged(nameof(Addent1Enabled)); OnPropertyChanged(nameof(Addent2Enabled));
                    _allHistory.Add(new PPWObject(_addent1, _addent2, _sum));

                    /*if (_decompositionLevel > 0)
                    {
                        StreakCorrect++; StreakWrong = 0;
                        if (StreakCorrect >= 20)
                        {
                            DecompositionLevel++; StreakCorrect = 0;
                            if (_decompositionLevel > 3)
                            {

                                //if(ASSERT) SentrySdk.CaptureMessage("Win");
                                App.Current.MainPage.DisplayAlert("Win", "You Won!!", "OK");
                                return "YOU WON!!!!!!";
                            }
                        }
                    }*/
                    //if (ASSERT) SentrySdk.CaptureMessage("Correct");
                    //SentrySdk.CaptureMessage(string.Format("  Correct: {0}={1}+{2}", _sum, _addent1, _addent2));

                    IsEnabledTotal = false;
                    NotifyPropertyChanged(nameof(History));
                    return "CORRECT :D";
                }
                else
                {

                    /*if (_decompositionLevel > 0)
                    {
                        StreakWrong++;
                        if (StreakWrong > 5)
                        {
                            DecompositionLevel--; StreakCorrect = 0; StreakWrong = 0;
                            if (_decompositionLevel == 0)
                            {
                                //if (ASSERT) SentrySdk.CaptureMessage("Lose");

                                App.Current.MainPage.DisplayAlert("Lose", "You Lost!!", "OK");
                                return "YOU LOST!!!!!!";
                            }
                        }
                    }*/
                    //if (ASSERT) SentrySdk.CaptureMessage("Incorrect");
                    //SentrySdk.CaptureMessage(string.Format("Incorrect: {0}={1}+{2}", _sum, _addent1, _addent2));
                    
                    return "WRONG :(";
                }
            }
        }




        //TODO:Add long press

        public ICommand CheckCommand { get; private set; }
        public ICommand NextCommand { get; private set; }
        readonly MR.Gestures.Button[] _keys;
        readonly private bool _isSync;

        public ButtonViewModel(bool isSync) {
            this._isSync = isSync;
            _keys = new MR.Gestures.Button[10];
            for (int i = 0; i < _keys.Length; i++)
            {

            }
            CheckCommand = new Command(() => Check());
            NextCommand = new Command(() => GenerateExercise());
        }

    public void Check() { _isFirstGuess = false; NotifyPropertyChanged(nameof(isNotFirstGuess)); NotifyPropertyChanged(nameof(TrueStatement)); }

        int _minAddent = 0;
        int _maxAddent = 5;
        int _minSum = 1;
        int _maxSum = 10;
        //int _decompositionLevel = -1;
        int _fMustFindOneTwoBoth = 2;

        bool _fMustFindTheSum = true;
        bool _requireNewAddents = true;
        bool _freeCombination = true;


        private List<PPWObject> _allHistory = new();
        private List<int> _impossibleSums = new();
        public String History
        {
            get
            {
                String s = "";
                if (_requireNewAddents && _sum != NAN)
                {
                    s = "HISTORY:\n";
                    foreach (PPWObject ppw in _allHistory)
                        if (ppw.Sum == _sum)
                            s += ppw.Addent1 + "\t" + ppw.Addent2 + "\n";
                }

                return s;
                //return allHistory;
            }
        }

        private int GenerateNewAddent(int newSum)
        {
            ArrayList possibleAddents = new();
            for (int i = Math.Max(_minAddent, newSum - _maxAddent); i <= Math.Min(_maxAddent, newSum - _minAddent); i++)
            {
                bool isExist = false;
                foreach (PPWObject ppw in _allHistory)
                    if (ppw.Sum == newSum && ppw.Addent1 == i) isExist = true;
                if (!isExist)
                    possibleAddents.Add(i);
            }
            if (possibleAddents.Count > 0) { Random r = new(); return (int)possibleAddents[r.Next(possibleAddents.Count)]; }

            if (!_impossibleSums.Contains(newSum)) _impossibleSums.Add(newSum);
            return NAN;
        }

        

        public void GenerateExercise()
        {
            _isFirstGuess = true;
            //if (ASSERT)
            //    SentrySdk.CaptureMessage("Hello Sentry");
            /*if (_decompositionLevel == 1) { MinAddent = 0; MaxAddent = 10; MaxSum = 10; FInsisitentOnOne = true; }
            if (_decompositionLevel == 2) { MinAddent = 0; MaxAddent = 20; MaxSum = 20; FInsisitentOnOne = false; }
            if (_decompositionLevel == 3) { MinAddent = 0; MaxAddent = 100; MaxSum = 100; }
            //TODO: validation also in the form with Binding
            if (_minAddent < 0) MinAddent = 0;
            if (_maxAddent < _minAddent + 3) MaxAddent = _minAddent + 2;
            if (_maxSum > 2 * _maxAddent || _maxSum <= 2 * _minAddent) MaxSum = 2 * _maxAddent;
            */

            int[] factors = new int[3];
            Random r = new();
            factors[2] = r.Next(_minSum, _maxSum + 1);
            //if (_fInsisitentOnOne) factors[2] = _lastNum;
            factors[0] = r.Next(_minAddent, Math.Min(_maxAddent, factors[2]) + 1);
            factors[1] = factors[2] - factors[0];

            //if (ASSERT)
            //    SentrySdk.CaptureMessage("First factors success");



            /*if (_decompositionLevel > 1)
            {

                if (_sum != _addent1 + _addent2) StreakWrong++;//you moved next without solving
                int minSum = (_decompositionLevel >= 3) ? 20 : 10;
                factors[2] = r.Next(Math.Max(_minAddent, minSum), _maxSum);
                while (factors[2] % 10 == 9) factors[2] = r.Next(Math.Max(_minAddent, minSum), _maxSum);
                if (factors[2] % 10 == 0) factors[0] = r.Next(_minAddent, Math.Min(_maxAddent + 1, factors[2]));
                else
                {

                    int tens = r.Next(Math.Max(_minAddent / 10, 0), factors[2] / 10 - 1);
                    int ones = r.Next(factors[2] % 10 + 1, 10);
                    factors[0] = tens * 10 + ones;
                }
                factors[1] = factors[2] - factors[0];
            }*/
            //if (ASSERT)
            //    SentrySdk.CaptureMessage("Second factors success");


            int questionType;
            if (_fMustFindOneTwoBoth == 1) questionType = 1;
            else if (_fMustFindOneTwoBoth == 2) questionType = 2;
            else questionType = r.Next(2);
            int n = r.Next(3);
            if (_fMustFindTheSum) n = 2;
            if (questionType == 1)
                factors[n] = NAN;
            else
                for (int i = 0; i < 3; i++)
                    if (i != n) factors[i] = NAN;
            //if (ASSERT)
            //    SentrySdk.CaptureMessage("Xs success");

            if (_requireNewAddents)
            {
                //make some win message before arriving to it
                if (_impossibleSums.Count >= _maxSum - 2 * _minAddent - 1)
                {
                    _impossibleSums.Clear(); _allHistory.Clear(); _freeCombination = !_freeCombination;
                }
                factors[0] = GenerateNewAddent(factors[2]);
                if (_freeCombination) factors[0] = NAN;
                while (_impossibleSums.Contains(factors[2]))
                {
                    if (_impossibleSums.Count >= _maxSum - 2 * _minAddent - 1)
                    {
                        _impossibleSums.Clear(); _allHistory.Clear(); _freeCombination = !_freeCombination;
                    }
                    factors[2] = r.Next(2 * _minAddent, _maxSum + 1);
                    factors[0] = GenerateNewAddent(factors[2]);
                    if (_freeCombination) factors[0] = NAN;
                }
                
                
            }


            //SAddent1 = factors[0].ToString();
            //SAddent2 = factors[1].ToString();
            SSum = factors[2].ToString();NotifyPropertyChanged(nameof(History));
            
            NotifyPropertyChanged(nameof(TrueStatement));
            IsEnabledTotal = true;

            NotifyPropertyChanged(nameof(isNotFirstGuess));
            //NotifyPropertyChanged(SSum);
            _addent1 = 0;
            _addent2 = 0;
            NotifyPropertyChanged(nameof(SAddent1));
            NotifyPropertyChanged(nameof(SAddent2));
            //Color = 
            //Color = Color.FromArgb("808080");
            STest = "";
            foreach(VisualElement ve in buttons) ve.BackgroundColor= Color.FromArgb("808080");
            buttons.Clear();
            //Button[] buttons = this.Controls.OfType<Button>().ToArray();


            //SentrySdk.CaptureMessage(string.Format("Question:{0}={1}+{2}", SSum, SAddent1, SAddent2));

            //if (ASSERT)
            //    SentrySdk.CaptureMessage("Pulling the entries success");



        }

        private List<VisualElement> buttons = new();
        private int _seconds_pressed = 0;
        public string SecondsToEnd
        {
            get
            {
                return string.Format("{0}",5 - _seconds_pressed);
            }
        }
        private bool _waiting_check = false;
        private bool _isTimerWorking = false;
        protected override void OnDown(MR.Gestures.DownUpEventArgs e)
		{
            
            if (!IsEnabledTotal) return;
            //AddText2("{0} was clicked.", ((Button)e.Sender).CommandParameter);
            base.OnDown(e);
            buttons.Add((VisualElement)e.Sender);
            if (_isSync)
            {
                ((VisualElement)e.Sender).BackgroundColor = Colors.Yellow;
                if (Convert.ToInt32(((Button)e.Sender).CommandParameter) > 4)
                    _addent2++;
                else
                    _addent1++;
                if(_addent1==0 && _addent2==0) { _isTimerWorking = false; _waiting_check = false; _seconds_pressed = 0; return; }
                _waiting_check = true;
                _seconds_pressed = 0;
                if(!_isTimerWorking)
                { 
                    _isTimerWorking = true;
                    /*IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += (s,e) => {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                       
                            _seconds_pressed++;
                            if (_seconds_pressed == 5 && _waiting_check)
                            {
                                _isTimerWorking = false; _waiting_check = false; _seconds_pressed = 0;
                                check();
                            }
                            NotifyPropertyChanged(nameof(SecondsToEnd));
                        });
                    };*/
                }
            }
            else
            {
                if (((VisualElement)e.Sender).BackgroundColor != Colors.Yellow)

                    ((VisualElement)e.Sender).BackgroundColor = Colors.Yellow;

                else
                    ((VisualElement)e.Sender).BackgroundColor = Color.FromArgb("808080");
                
            }
            
            NotifyPropertyChanged(nameof(SAddent1)); NotifyPropertyChanged(nameof(SAddent2)); NotifyPropertyChanged(nameof(SecondsToEnd));
        }

		protected override void OnUp(MR.Gestures.DownUpEventArgs e)
        {

            
            if (!IsEnabledTotal) return;
            base.OnUp(e);
            if (_isSync)
            {
                _seconds_pressed = 0;
                ((VisualElement)e.Sender).BackgroundColor = Color.FromArgb("808080");
                if (Convert.ToInt32(((Button)e.Sender).CommandParameter) > 4)
                    _addent2--;
                else
                    _addent1--;
                if (_addent1 == 0 && _addent2 == 0) { _isTimerWorking = false; _waiting_check = false; _seconds_pressed = 0; }

            }
            else
            {

                if (Convert.ToInt32(((Button)e.Sender).CommandParameter) > 4)
                    if (((VisualElement)e.Sender).BackgroundColor != Colors.Yellow)
                        _addent2--;
                    else
                        _addent2++;
                else
                    if (((VisualElement)e.Sender).BackgroundColor != Colors.Yellow)
                    _addent1--;
                else
                    _addent1++;
            }
            //AddText2("{0} {1}", _addent1, _addent2);
            NotifyPropertyChanged(nameof(SAddent1)); NotifyPropertyChanged(nameof(SAddent2)); NotifyPropertyChanged(nameof(SecondsToEnd));
        }
    }
}
