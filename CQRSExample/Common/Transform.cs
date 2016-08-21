namespace Common
{
    public struct Transform<T> where T: struct 
    {
        private readonly T? _initialValue;
        private readonly T? _finalValue;

        public Transform(T initialValue, T finalValue) : this((T?)initialValue, (T?)finalValue)
        {
        }

        public Transform(T? initialValue, T finalValue) : this((T?) initialValue, (T?) finalValue)
        {
        }

        public Transform(T initialValue, T? finalValue) : this((T?)initialValue, (T?)finalValue)
        {
        }

        private Transform(T? initialValue, T? finalValue)
        {
            _initialValue = initialValue;
            _finalValue = finalValue;
        }

        public T? FinalValue
        {
            get { return _finalValue; }
        }

        public T? InitialValue
        {
            get { return _initialValue; }
        }
    }
}