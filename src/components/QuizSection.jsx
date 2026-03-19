import { useState, useCallback } from 'react';
import { vocabulary } from '../data/vocabulary';
import styles from './QuizSection.module.css';

function shuffle(arr) {
  return [...arr].sort(() => Math.random() - 0.5);
}

function generateQuestions(words, count = 10) {
  const pool = shuffle(words).slice(0, count);
  return pool.map((word) => {
    const distractors = shuffle(words.filter((w) => w.id !== word.id)).slice(0, 3);
    const options = shuffle([word, ...distractors]);
    return { word, options };
  });
}

export default function QuizSection() {
  const [questions, setQuestions] = useState(() => generateQuestions(vocabulary));
  const [current, setCurrent] = useState(0);
  const [selected, setSelected] = useState(null);
  const [score, setScore] = useState(0);
  const [finished, setFinished] = useState(false);
  const [answered, setAnswered] = useState(false);

  const question = questions[current];
  const progress = ((current) / questions.length) * 100;

  const handleAnswer = useCallback((option) => {
    if (answered) return;
    setSelected(option.id);
    setAnswered(true);
    if (option.id === question.word.id) {
      setScore((s) => s + 1);
    }
  }, [answered, question]);

  const handleNext = () => {
    if (current + 1 >= questions.length) {
      setFinished(true);
    } else {
      setCurrent((c) => c + 1);
      setSelected(null);
      setAnswered(false);
    }
  };

  const handleRestart = () => {
    setQuestions(generateQuestions(vocabulary));
    setCurrent(0);
    setSelected(null);
    setScore(0);
    setFinished(false);
    setAnswered(false);
  };

  const scorePercent = Math.round((score / questions.length) * 100);
  const scoreMessage = scorePercent >= 80
    ? 'Excellent work! 🌟'
    : scorePercent >= 60
    ? 'Good job! Keep practicing! 👍'
    : 'Keep studying, you\'ll improve! 💪';

  if (finished) {
    return (
      <div className={styles.section}>
        <div className={styles.resultCard}>
          <div className={styles.resultEmoji}>{scorePercent >= 80 ? '🏆' : scorePercent >= 60 ? '⭐' : '📖'}</div>
          <h2 className={styles.resultTitle}>Quiz Complete!</h2>
          <div className={styles.scoreCircle}>
            <span className={styles.scoreNum}>{score}</span>
            <span className={styles.scoreDenom}>/{questions.length}</span>
          </div>
          <p className={styles.scorePercent}>{scorePercent}% correct</p>
          <p className={styles.scoreMessage}>{scoreMessage}</p>
          <div className={styles.scoreBar}>
            <div className={styles.scoreBarFill} style={{ width: `${scorePercent}%` }} />
          </div>
          <button className={styles.restartBtn} onClick={handleRestart}>
            Try Again
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className={styles.section}>
      <div className={styles.header}>
        <h1 className={styles.title}>Arabic Quiz</h1>
        <p className={styles.subtitle}>Choose the correct English translation</p>
      </div>

      <div className={styles.progressBar}>
        <div className={styles.progressFill} style={{ width: `${progress}%` }} />
      </div>
      <div className={styles.progressLabel}>
        Question {current + 1} of {questions.length} · Score: {score}
      </div>

      <div className={styles.questionCard}>
        <p className={styles.questionPrompt}>What does this mean?</p>
        <div className={`${styles.questionWord} arabic`} dir="rtl">
          {question.word.arabic}
        </div>
        <div className={styles.questionTranslit}>{question.word.transliteration}</div>
      </div>

      <div className={styles.options}>
        {question.options.map((option) => {
          let optionClass = styles.option;
          if (answered) {
            if (option.id === question.word.id) optionClass = `${styles.option} ${styles.optionCorrect}`;
            else if (option.id === selected) optionClass = `${styles.option} ${styles.optionWrong}`;
            else optionClass = `${styles.option} ${styles.optionDimmed}`;
          }
          return (
            <button
              key={option.id}
              className={optionClass}
              onClick={() => handleAnswer(option)}
              disabled={answered}
            >
              {option.english}
            </button>
          );
        })}
      </div>

      {answered && (
        <div className={styles.feedback}>
          {selected === question.word.id
            ? <span className={styles.correct}>✓ Correct!</span>
            : <span className={styles.wrong}>✗ The answer was: <strong>{question.word.english}</strong></span>
          }
          <button className={styles.nextBtn} onClick={handleNext}>
            {current + 1 >= questions.length ? 'See Results' : 'Next Question →'}
          </button>
        </div>
      )}
    </div>
  );
}
