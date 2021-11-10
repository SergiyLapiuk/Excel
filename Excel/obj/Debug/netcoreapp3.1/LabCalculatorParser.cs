﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\acer\Desktop\blyat\Excel\LabCalculator.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Excel {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class LabCalculatorParser : Parser {
	public const int
		NUMBER=1, IDENTIFIER=2, INT=3, MOD=4, DIV=5, COMA=6, EXPONENT=7, MULTIPLY=8, 
		DIVIDE=9, SUBTRACT=10, ADD=11, LPAREN=12, RPAREN=13, WS=14;
	public const int
		RULE_compileUnit = 0, RULE_expression = 1;
	public static readonly string[] ruleNames = {
		"compileUnit", "expression"
	};

	private static readonly string[] _LiteralNames = {
		null, null, null, null, "'mod'", "'div'", "','", "'^'", "'*'", "'/'", 
		"'-'", "'+'", "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "NUMBER", "IDENTIFIER", "INT", "MOD", "DIV", "COMA", "EXPONENT", 
		"MULTIPLY", "DIVIDE", "SUBTRACT", "ADD", "LPAREN", "RPAREN", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "LabCalculator.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public LabCalculatorParser(ITokenStream input)
		: base(input)
	{
		_interp = new ParserATNSimulator(this,_ATN);
	}
	public partial class CompileUnitContext : ParserRuleContext {
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode Eof() { return GetToken(LabCalculatorParser.Eof, 0); }
		public CompileUnitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_compileUnit; } }
		public override void EnterRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.EnterCompileUnit(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.ExitCompileUnit(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabCalculatorVisitor<TResult> typedVisitor = visitor as ILabCalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCompileUnit(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CompileUnitContext compileUnit() {
		CompileUnitContext _localctx = new CompileUnitContext(_ctx, State);
		EnterRule(_localctx, 0, RULE_compileUnit);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 4; expression(0);
			State = 5; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
	 
		public ExpressionContext() { }
		public virtual void CopyFrom(ExpressionContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class ParenthesizedExprContext : ExpressionContext {
		public ITerminalNode LPAREN() { return GetToken(LabCalculatorParser.LPAREN, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode RPAREN() { return GetToken(LabCalculatorParser.RPAREN, 0); }
		public ParenthesizedExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.EnterParenthesizedExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.ExitParenthesizedExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabCalculatorVisitor<TResult> typedVisitor = visitor as ILabCalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParenthesizedExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ExponentialExprContext : ExpressionContext {
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode EXPONENT() { return GetToken(LabCalculatorParser.EXPONENT, 0); }
		public ExponentialExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.EnterExponentialExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.ExitExponentialExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabCalculatorVisitor<TResult> typedVisitor = visitor as ILabCalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExponentialExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MultiplicativeExprContext : ExpressionContext {
		public IToken operatorToken;
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode MULTIPLY() { return GetToken(LabCalculatorParser.MULTIPLY, 0); }
		public ITerminalNode DIVIDE() { return GetToken(LabCalculatorParser.DIVIDE, 0); }
		public MultiplicativeExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.EnterMultiplicativeExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.ExitMultiplicativeExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabCalculatorVisitor<TResult> typedVisitor = visitor as ILabCalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMultiplicativeExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class UnaryAdditiveExprContext : ExpressionContext {
		public IToken operatorToken;
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode ADD() { return GetToken(LabCalculatorParser.ADD, 0); }
		public ITerminalNode SUBTRACT() { return GetToken(LabCalculatorParser.SUBTRACT, 0); }
		public UnaryAdditiveExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.EnterUnaryAdditiveExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.ExitUnaryAdditiveExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabCalculatorVisitor<TResult> typedVisitor = visitor as ILabCalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitUnaryAdditiveExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class AdditiveExprContext : ExpressionContext {
		public IToken operatorToken;
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode ADD() { return GetToken(LabCalculatorParser.ADD, 0); }
		public ITerminalNode SUBTRACT() { return GetToken(LabCalculatorParser.SUBTRACT, 0); }
		public AdditiveExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.EnterAdditiveExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.ExitAdditiveExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabCalculatorVisitor<TResult> typedVisitor = visitor as ILabCalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAdditiveExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ModDivExprContext : ExpressionContext {
		public IToken operatorToken;
		public ITerminalNode LPAREN() { return GetToken(LabCalculatorParser.LPAREN, 0); }
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode COMA() { return GetToken(LabCalculatorParser.COMA, 0); }
		public ITerminalNode RPAREN() { return GetToken(LabCalculatorParser.RPAREN, 0); }
		public ITerminalNode MOD() { return GetToken(LabCalculatorParser.MOD, 0); }
		public ITerminalNode DIV() { return GetToken(LabCalculatorParser.DIV, 0); }
		public ModDivExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.EnterModDivExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.ExitModDivExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabCalculatorVisitor<TResult> typedVisitor = visitor as ILabCalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitModDivExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class NumberExprContext : ExpressionContext {
		public ITerminalNode NUMBER() { return GetToken(LabCalculatorParser.NUMBER, 0); }
		public NumberExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.EnterNumberExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.ExitNumberExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabCalculatorVisitor<TResult> typedVisitor = visitor as ILabCalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumberExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IdentifierExprContext : ExpressionContext {
		public ITerminalNode IDENTIFIER() { return GetToken(LabCalculatorParser.IDENTIFIER, 0); }
		public IdentifierExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.EnterIdentifierExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILabCalculatorListener typedListener = listener as ILabCalculatorListener;
			if (typedListener != null) typedListener.ExitIdentifierExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILabCalculatorVisitor<TResult> typedVisitor = visitor as ILabCalculatorVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIdentifierExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		return expression(0);
	}

	private ExpressionContext expression(int _p) {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = State;
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 2;
		EnterRecursionRule(_localctx, 2, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 23;
			_errHandler.Sync(this);
			switch (_input.La(1)) {
			case LPAREN:
				{
				_localctx = new ParenthesizedExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				State = 8; Match(LPAREN);
				State = 9; expression(0);
				State = 10; Match(RPAREN);
				}
				break;
			case SUBTRACT:
			case ADD:
				{
				_localctx = new UnaryAdditiveExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				State = 12;
				((UnaryAdditiveExprContext)_localctx).operatorToken = _input.Lt(1);
				_la = _input.La(1);
				if ( !(_la==SUBTRACT || _la==ADD) ) {
					((UnaryAdditiveExprContext)_localctx).operatorToken = _errHandler.RecoverInline(this);
				} else {
					if (_input.La(1) == TokenConstants.Eof) {
						matchedEOF = true;
					}

					_errHandler.ReportMatch(this);
					Consume();
				}
				State = 13; expression(5);
				}
				break;
			case MOD:
			case DIV:
				{
				_localctx = new ModDivExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				State = 14;
				((ModDivExprContext)_localctx).operatorToken = _input.Lt(1);
				_la = _input.La(1);
				if ( !(_la==MOD || _la==DIV) ) {
					((ModDivExprContext)_localctx).operatorToken = _errHandler.RecoverInline(this);
				} else {
					if (_input.La(1) == TokenConstants.Eof) {
						matchedEOF = true;
					}

					_errHandler.ReportMatch(this);
					Consume();
				}
				State = 15; Match(LPAREN);
				State = 16; expression(0);
				State = 17; Match(COMA);
				State = 18; expression(0);
				State = 19; Match(RPAREN);
				}
				break;
			case NUMBER:
				{
				_localctx = new NumberExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				State = 21; Match(NUMBER);
				}
				break;
			case IDENTIFIER:
				{
				_localctx = new IdentifierExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				State = 22; Match(IDENTIFIER);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.Lt(-1);
			State = 36;
			_errHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.InvalidAltNumber ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 34;
					_errHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(_input,1,_ctx) ) {
					case 1:
						{
						_localctx = new ExponentialExprContext(new ExpressionContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 25;
						if (!(Precpred(_ctx, 7))) throw new FailedPredicateException(this, "Precpred(_ctx, 7)");
						State = 26; Match(EXPONENT);
						State = 27; expression(8);
						}
						break;

					case 2:
						{
						_localctx = new MultiplicativeExprContext(new ExpressionContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 28;
						if (!(Precpred(_ctx, 6))) throw new FailedPredicateException(this, "Precpred(_ctx, 6)");
						State = 29;
						((MultiplicativeExprContext)_localctx).operatorToken = _input.Lt(1);
						_la = _input.La(1);
						if ( !(_la==MULTIPLY || _la==DIVIDE) ) {
							((MultiplicativeExprContext)_localctx).operatorToken = _errHandler.RecoverInline(this);
						} else {
							if (_input.La(1) == TokenConstants.Eof) {
								matchedEOF = true;
							}

							_errHandler.ReportMatch(this);
							Consume();
						}
						State = 30; expression(7);
						}
						break;

					case 3:
						{
						_localctx = new AdditiveExprContext(new ExpressionContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 31;
						if (!(Precpred(_ctx, 4))) throw new FailedPredicateException(this, "Precpred(_ctx, 4)");
						State = 32;
						((AdditiveExprContext)_localctx).operatorToken = _input.Lt(1);
						_la = _input.La(1);
						if ( !(_la==SUBTRACT || _la==ADD) ) {
							((AdditiveExprContext)_localctx).operatorToken = _errHandler.RecoverInline(this);
						} else {
							if (_input.La(1) == TokenConstants.Eof) {
								matchedEOF = true;
							}

							_errHandler.ReportMatch(this);
							Consume();
						}
						State = 33; expression(5);
						}
						break;
					}
					} 
				}
				State = 38;
				_errHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(_input,2,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1: return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(_ctx, 7);

		case 1: return Precpred(_ctx, 6);

		case 2: return Precpred(_ctx, 4);
		}
		return true;
	}

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x3\x10*\x4\x2\t\x2"+
		"\x4\x3\t\x3\x3\x2\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x5\x3\x1A\n\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\a\x3%\n\x3\f\x3"+
		"\xE\x3(\v\x3\x3\x3\x2\x2\x3\x4\x4\x2\x2\x4\x2\x2\x5\x3\x2\f\r\x3\x2\x6"+
		"\a\x3\x2\n\v.\x2\x6\x3\x2\x2\x2\x4\x19\x3\x2\x2\x2\x6\a\x5\x4\x3\x2\a"+
		"\b\a\x2\x2\x3\b\x3\x3\x2\x2\x2\t\n\b\x3\x1\x2\n\v\a\xE\x2\x2\v\f\x5\x4"+
		"\x3\x2\f\r\a\xF\x2\x2\r\x1A\x3\x2\x2\x2\xE\xF\t\x2\x2\x2\xF\x1A\x5\x4"+
		"\x3\a\x10\x11\t\x3\x2\x2\x11\x12\a\xE\x2\x2\x12\x13\x5\x4\x3\x2\x13\x14"+
		"\a\b\x2\x2\x14\x15\x5\x4\x3\x2\x15\x16\a\xF\x2\x2\x16\x1A\x3\x2\x2\x2"+
		"\x17\x1A\a\x3\x2\x2\x18\x1A\a\x4\x2\x2\x19\t\x3\x2\x2\x2\x19\xE\x3\x2"+
		"\x2\x2\x19\x10\x3\x2\x2\x2\x19\x17\x3\x2\x2\x2\x19\x18\x3\x2\x2\x2\x1A"+
		"&\x3\x2\x2\x2\x1B\x1C\f\t\x2\x2\x1C\x1D\a\t\x2\x2\x1D%\x5\x4\x3\n\x1E"+
		"\x1F\f\b\x2\x2\x1F \t\x4\x2\x2 %\x5\x4\x3\t!\"\f\x6\x2\x2\"#\t\x2\x2\x2"+
		"#%\x5\x4\x3\a$\x1B\x3\x2\x2\x2$\x1E\x3\x2\x2\x2$!\x3\x2\x2\x2%(\x3\x2"+
		"\x2\x2&$\x3\x2\x2\x2&\'\x3\x2\x2\x2\'\x5\x3\x2\x2\x2(&\x3\x2\x2\x2\x5"+
		"\x19$&";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Excel
