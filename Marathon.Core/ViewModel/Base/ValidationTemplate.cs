using System;
using System.Linq;
using FluentValidation;
using System.Collections;
using System.ComponentModel;
using FluentValidation.Results;
using System.Collections.Concurrent;

namespace Marathon.Core.ViewModel.Base
{
    public class ValidationTemplate : IDataErrorInfo, INotifyDataErrorInfo
    {
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IValidator> Validators;

        private readonly INotifyPropertyChanged _target;
        private readonly IValidator _validator;
        private ValidationResult _validationResult;

        public ValidationTemplate(INotifyPropertyChanged target)
        {
            _target = target;
            _validator = GetValidator(target.GetType());
            _validationResult = _validator.Validate(target);
            target.PropertyChanged += Validate;
        }

        static ValidationTemplate()
        {
            Validators = new ConcurrentDictionary<RuntimeTypeHandle, IValidator>();
        }

        public string this[string propertyName]
        {
            get
            {
                var strings = _validationResult.Errors.Where(x => x.PropertyName == propertyName)
                                              .Select(x => x.ErrorMessage)
                                              .ToArray();
                return string.Join(Environment.NewLine, strings);
            }
        }

        public bool HasErrors => _validationResult.Errors.Count > 0;

        public string Error
        {
            get
            {
                var strings = _validationResult.Errors
                                                .Select(x => x.ErrorMessage)
                                                .ToArray();
                return string.Join(Environment.NewLine, strings);
            }
        }

        private static IValidator GetValidator(Type modelType)
        {
            if (!Validators.TryGetValue(modelType.TypeHandle, out var validator))
            {
                var typeName = string.Format("{0}.{1}Validator", modelType.Namespace, modelType.Name);
                var type = modelType.Assembly.GetType(typeName, true);
                Validators[modelType.TypeHandle] = validator = (IValidator)Activator.CreateInstance(type);
            }
            return validator;
        }

        private void Validate(object sender, PropertyChangedEventArgs e)
        {
            _validationResult = _validator.Validate(_target);
            foreach (var error in _validationResult.Errors)
            {
                RaiseErrorsChanged(error.PropertyName);
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _validationResult.Errors
                                    .Where(x => x.PropertyName == propertyName)
                                    .Select(x => x.ErrorMessage);
        }

        private void RaiseErrorsChanged(string propertyName)
        {
            var handler = ErrorsChanged;
            handler?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
