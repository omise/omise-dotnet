using System;

namespace Omise.Models {
    public sealed class Ordering {
        public static Ordering Chronological = new Ordering("chronological");
        public static Ordering ReverseChronological = new Ordering("reverse_chronological");

        readonly string value;

        Ordering(string value) {
            this.value = value;
        }

        public override string ToString() {
            return value;
        }
    }
}

