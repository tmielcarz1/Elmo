using System.Text.Json.Serialization;

namespace Elmo.Infrastructure.Common.Models
{
    public class State
    {
        #region Properties

        /// <summary>
        /// Returned object
        /// </summary>
        [JsonPropertyName("payload")]
        public object? StateObject { get; set; }

        [JsonPropertyName("statusCode")]
        public StatusCode StatusCode { get; set; } = StatusCode.Ok;

        /// <summary>
        /// Errors
        /// </summary>
        [JsonPropertyName("errors_debug")]
        public List<string> Errors { get; set; } = new List<string>();

        #endregion Properties

        #region Constructors

        /// <summary>
        /// State constructor
        /// </summary>
        public State()
        {
            Errors = new List<string>();
        }

        /// <summary>
        /// State constructor
        /// </summary>
        public State(List<string> errors)
        {
            Errors = errors;
        }

        #endregion Constructors

        #region Exception methods

        /// <summary>
        /// Method to add exception msg
        /// </summary>
        /// <param name="e">Exception</param>
        public void AddException(Exception e)
        {
            if (e.InnerException != null && !string.IsNullOrEmpty(e.InnerException.Message))
            {
                Errors.Add(e.InnerException.Message);
            }
            if (!string.IsNullOrEmpty(e.Message))
            {
                Errors.Add(e.Message);
            }
        }

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="err"></param>
        public void AddError(string err)
        {
            if (!Errors.Contains(err))
            {
                Errors.Add(err);
            }
        }

        #endregion Exception methods

        #region Check methods

        /// <summary>
        /// Check state of operation if false set error in RepoState
        /// </summary>
        /// <param name="state">State of function</param>
        /// <param name="errorMessage">Error message</param>
        public void ExecuteStatus(bool state, string errorMessage)
        {
            if (!state)
            {
                AddError(errorMessage);
            }
        }

        #endregion Check methods

        /// <summary>
        /// Gets errors
        /// </summary>
        /// <returns></returns>
        #region OtherMethods
        public string GetErrors()
        {
            return string.Join("\n", Errors);
        }

        #endregion
    }

    public class State<TResult>
    {
        #region Properties

        /// <summary>
        /// Returned object
        /// </summary>
        [JsonPropertyName("payload")]
        public TResult? StateObject { get; set; }

        [JsonPropertyName("statusCode")]
        public StatusCode StatusCode { get; set; } = StatusCode.Ok;

        /// <summary>
        /// Errors
        /// </summary>
        [JsonPropertyName("errors_debug")]
        public List<string> Errors { get; set; } = new List<string>();

        #endregion Properties

        #region Constructors

        /// <summary>
        /// State constructor
        /// </summary>
        public State()
        {
            Errors = new List<string>();
        }

        /// <summary>
        /// State constructor
        /// </summary>
        public State(List<string> errors)
        {
            Errors = errors;
        }

        #endregion Constructors

        #region Exception methods

        /// <summary>
        /// Method to add exception msg
        /// </summary>
        /// <param name="e">Exception</param>
        public void AddException(Exception e)
        {
            if (e.InnerException != null && !string.IsNullOrEmpty(e.InnerException.Message))
            {
                Errors.Add(e.InnerException.Message);
            }
            if (!string.IsNullOrEmpty(e.Message))
            {
                Errors.Add(e.Message);
            }
        }

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="err"></param>
        public void AddError(string err)
        {
            if (!Errors.Contains(err))
            {
                Errors.Add(err);
            }
        }

        /// <summary>
        /// Add errors
        /// </summary>
        /// <param name="errs"></param>
        public void AddErrors(List<string> errs)
        {
            Errors.AddRange(errs);
        }

        #endregion Exception methods

        #region Check methods

        /// <summary>
        /// Check state of operation if false set error in RepoState
        /// </summary>
        /// <param name="state">State of function</param>
        /// <param name="errorMessage">Error message</param>
        public void ExecuteStatus(bool state, string errorMessage)
        {
            if (!state)
            {
                AddError(errorMessage);
            }
        }

        #endregion Check methods

        /// <summary>
        /// Gets errors
        /// </summary>
        /// <returns></returns>
        #region OtherMethods
        public string GetErrors()
        {
            return string.Join("\n", Errors.Distinct());
        }

        #endregion
    }
}
