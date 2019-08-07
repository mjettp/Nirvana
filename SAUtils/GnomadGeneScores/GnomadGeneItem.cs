﻿using System;
using OptimizedCore;
using VariantAnnotation.Interface.SA;
using VariantAnnotation.IO;

namespace SAUtils.GnomadGeneScores
{
    public sealed class GnomadGeneItem : ISuppGeneItem, IComparable<GnomadGeneItem>
    {
        public string GeneSymbol { get; }
        private readonly double? _pLI;
        private readonly double? _pRec;
        private readonly double? _pNull;
        private readonly double? _synZ;
        private readonly double? _misZ;
        private readonly double? _loeuf;


        public GnomadGeneItem(string gene, double? pLi, double? pRec, double? pNull, double? synZ, double? misZ, double? loeuf)
        {
            GeneSymbol = gene;
            _pLI       = pLi;
            _pRec      = pRec;
            _pNull     = pNull;
            _synZ      = synZ;
            _misZ      = misZ;
            _loeuf     = loeuf;
        }


        public string GetJsonString()
        {
            var sb = StringBuilderCache.Acquire();
            var jsonObject = new JsonObject(sb);

            sb.Append(JsonObject.OpenBrace);
            jsonObject.AddDoubleValue("pLi", _pLI, "0.00e0");
            jsonObject.AddDoubleValue("pRec", _pRec, "0.00e0");
            jsonObject.AddDoubleValue("pNull", _pNull, "0.00e0");
            jsonObject.AddDoubleValue("synZ", _synZ, "0.00e0");
            jsonObject.AddDoubleValue("misZ", _misZ, "0.00e0");
            jsonObject.AddDoubleValue("loeuf", _loeuf, "0.00e0");
            sb.Append(JsonObject.CloseBrace);

            return StringBuilderCache.GetStringAndRelease(sb);

        }

        public int CompareTo(GnomadGeneItem other)
        {
            if (_loeuf == null) return 1;
            if (other._loeuf == null) return -1;

            return _loeuf.Value.CompareTo(other._loeuf.Value);
        }
    }
}