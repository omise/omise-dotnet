namespace Omise {
    public struct Key {
        string value;

        public bool IsTest { get { return value.Contains("_test_"); } }
        public bool IsLive { get { return !IsTest; } }

        public static implicit operator Key(string value) {
            return new Key { value = value };
        }

        public static implicit operator string(Key key) {
            return key.value;
        }

        public override string ToString() {
            return this;
        }
    }
}

