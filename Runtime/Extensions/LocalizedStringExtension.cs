using System;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace ActionCode.LocalizationSystem
{
    /// <summary>
    /// Extensions for <see cref="LocalizedString"/> instances.
    /// </summary>
    public static class LocalizedStringExtension
    {
        /// <summary>
        /// Tries to get the dynamic variable from the given localization Local Variables.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="localization"></param>
        /// <param name="variableName">The dynamic variable name inside the Local Variables.</param>
        /// <param name="variable">The outputted variable if exists.</param>
        /// <returns>Whether the variable exists</returns>
        public static bool TryGetDynamicVariable<T>(this LocalizedString localization, string variableName, out T variable)
            where T : IVariable
        {
            var hasVariable = localization.ContainsKey(variableName);
            variable = hasVariable ? (T)localization[variableName] : default;
            return hasVariable;
        }

        /// <summary>
        /// Gets the dynamic variable from the given localization Local Variables.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="TryGetDynamicVariable{T}(LocalizedString, string, out T)" path="/param[@name='variableName']"/></param>
        /// <returns>The dynamic variable if exists.</returns>
        /// <exception cref="ArgumentException">If the variable does not exists.</exception>
        public static T GetDynamicVariable<T>(this LocalizedString localization, string variableName)
            where T : IVariable
        {
            var hasVariable = TryGetDynamicVariable(localization, variableName, out T variable);
            if (!hasVariable) throw new ArgumentException($"Variable '{variableName}' does not exists in '{localization}' Local Variables");
            return variable;
        }

        /// <summary>
        /// Updates the dynamic localization using the given variable name and value.
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName">The dynamic variable name inside the Local Variables.</param>
        /// <param name="value">The dynamic variable value inside the Local Variables.</param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, string value)
        {
            var variable = GetDynamicVariable<StringVariable>(localization, variableName);
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, int value)
        {
            var variable = GetDynamicVariable<IntVariable>(localization, variableName);
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, uint value)
        {
            var variable = GetDynamicVariable<UIntVariable>(localization, variableName);
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, bool value)
        {
            var variable = GetDynamicVariable<BoolVariable>(localization, variableName);
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, float value)
        {
            var variable = GetDynamicVariable<FloatVariable>(localization, variableName);
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        /// <param name="format">The Date Time format. Default is abbreviated date (d).</param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, DateTime value, string format = "d")
        {
            var variable = GetDynamicVariable<StringVariable>(localization, variableName);
            localization.StringChanged += _ =>
            {
                var code = UnityEngine.Localization.Settings.LocalizationSettings.SelectedLocale.Identifier.Code;
                var info = new System.Globalization.CultureInfo(code);
                variable.Value = value.ToString(format, info);
            };
        }
    }
}