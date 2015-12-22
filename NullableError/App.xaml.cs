#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NullableError
{
    sealed partial class App
    {
        private readonly Dictionary<String, String> _dictionary = new Dictionary<String, String>();

        public App()
        {
            InitializeComponent();

            Execute();
            Exit();
        }

        private Int64? NullableInt64
        {
            get
            {
                var resultString = this[nameof(NullableInt64)];
                return String.IsNullOrEmpty(resultString) ? default(Int64?) : Int64.Parse(resultString);
            }
            //-----FIX VARIANT------
            //UNCOMMENT NEXT LINE TO FIX 
            //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoOptimization)]
            set
            {
                //-----FIX VARIANT------
                //REPLACE WITH 
                //this[nameof(NullableInt64)] = value != null ? value.Value.ToString() : null;
                this[nameof(NullableInt64)] = value?.ToString();
            }
        }

        private Int64? AnotherNullableInt64
        {
            get
            {
                var resultString = this[nameof(AnotherNullableInt64)];
                return String.IsNullOrEmpty(resultString) ? default(Int64?) : Int64.Parse(resultString);
            }
            set { this[nameof(AnotherNullableInt64)] = value?.ToString(); }
        }

        private void Execute()
        {
            //-----FIX VARIANT------
            //REPLACE WITH IF-ELSE WITH
            //NullableInt64 = (DateTimeOffset.Now - DateTimeOffset.MinValue).TotalMilliseconds < 0 ? (Int64?) 125 : null;
            if ((DateTimeOffset.Now - DateTimeOffset.MinValue).TotalMilliseconds < 0)
            {
                Debug.WriteLine("-------------- IF ----------------");
                NullableInt64 = 125;
            }
            else
            {
                Debug.WriteLine("-------------- ELSE ----------------");
                NullableInt64 = null;
            }

            //-----FIX VARIANT------
            //REPLACE WITH 
            //AnotherNullableInt64 = 0;
            AnotherNullableInt64 = null;

            Debug.WriteLine($"-------------- {this[nameof(NullableInt64)] ?? "SUCCESS"} ----------------");
        }

        private String this[String key]
        {
            get
            {
                String result;
                return _dictionary.TryGetValue(key, out result) ? result : null;
            }
            set { _dictionary[key] = value; }
        }
    }
}