﻿using RuiJi.Core.Extracter;
using RuiJi.Core.Extracter.Enum;
using RuiJi.Core.Extracter.Selector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RuiJi.Core.Extracter.Processor
{
    /// <summary>
    /// exclude selector remove selector value
    /// </summary>
    public class ExcludeProcessor : ProcessorBase
    {
        public override ProcessResult ProcessNeed(ISelector selector, ProcessResult result)
        {
            var exSelector = selector as ExcludeSelector;
            var type = exSelector.Type;

            var pr = new ProcessResult();

            switch (type)
            {
                case ExcludeTypeEnum.ALL:
                    pr.Matches.Add(Regex.Replace(result.Content, exSelector.Value, ""));
                    break;
                case ExcludeTypeEnum.BEGIN:
                    pr.Matches.Add(Regex.Replace(result.Content, "^" + exSelector.Value, ""));
                    break;
                case ExcludeTypeEnum.END:
                    pr.Matches.Add(Regex.Replace(result.Content, exSelector.Value + "$", ""));
                    break;
            }

            return pr;
        }

        public override ProcessResult ProcessRemove(ISelector selector, ProcessResult result)
        {
            return ProcessNeed(selector, result);
        }
    }
}