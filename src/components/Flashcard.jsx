import { useState, useEffect } from 'react';
import styles from './Flashcard.module.css';

export default function Flashcard({ word }) {
  const [flipped, setFlipped] = useState(false);

  useEffect(() => {
    setFlipped(false);
  }, [word]);

  return (
    <div
      className={`${styles.cardScene}`}
      onClick={() => setFlipped(!flipped)}
      role="button"
      tabIndex={0}
      aria-label={flipped ? 'Flashcard showing English translation, click to flip' : 'Flashcard showing Arabic word, click to flip'}
      onKeyDown={(e) => e.key === 'Enter' || e.key === ' ' ? setFlipped(!flipped) : null}
    >
      <div className={`${styles.card} ${flipped ? styles.cardFlipped : ''}`}>
        <div className={styles.cardFront}>
          <div className={styles.frontHint}>Tap to reveal</div>
          <div className={`${styles.arabicWord} arabic`} dir="rtl">{word.arabic}</div>
          <div className={styles.categoryBadge}>{word.category}</div>
        </div>
        <div className={styles.cardBack}>
          <div className={styles.backHint}>Tap to flip back</div>
          <div className={styles.englishWord}>{word.english}</div>
          <div className={styles.transliteration}>{word.transliteration}</div>
          <div className={`${styles.arabicSmall} arabic`} dir="rtl">{word.arabic}</div>
        </div>
      </div>
    </div>
  );
}
