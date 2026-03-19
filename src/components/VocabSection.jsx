import { useState, useCallback } from 'react';
import { vocabulary, categories } from '../data/vocabulary';
import Flashcard from './Flashcard';
import styles from './VocabSection.module.css';

export default function VocabSection() {
  const [activeCategory, setActiveCategory] = useState('all');
  const [currentIndex, setCurrentIndex] = useState(0);

  const filtered = activeCategory === 'all'
    ? vocabulary
    : vocabulary.filter((w) => w.category === activeCategory);

  const handleCategoryChange = useCallback((catId) => {
    setActiveCategory(catId);
    setCurrentIndex(0);
  }, []);

  const handlePrev = () => setCurrentIndex((i) => (i - 1 + filtered.length) % filtered.length);
  const handleNext = () => setCurrentIndex((i) => (i + 1) % filtered.length);

  const current = filtered[currentIndex];

  return (
    <div className={styles.section}>
      <div className={styles.header}>
        <h1 className={styles.title}>Vocabulary Flashcards</h1>
        <p className={styles.subtitle}>Click a card to reveal the translation</p>
      </div>

      <div className={styles.categories}>
        {categories.map((cat) => (
          <button
            key={cat.id}
            className={`${styles.catBtn} ${activeCategory === cat.id ? styles.catBtnActive : ''}`}
            onClick={() => handleCategoryChange(cat.id)}
          >
            {cat.label}
          </button>
        ))}
      </div>

      <div className={styles.counter}>
        <span>{currentIndex + 1} / {filtered.length}</span>
      </div>

      <div className={styles.flashcardArea}>
        <button className={styles.arrowBtn} onClick={handlePrev} aria-label="Previous card">‹</button>
        {current && <Flashcard word={current} key={current.id} />}
        <button className={styles.arrowBtn} onClick={handleNext} aria-label="Next card">›</button>
      </div>

      <div className={styles.dotNav}>
        {filtered.map((_, i) => (
          <button
            key={i}
            className={`${styles.dot} ${i === currentIndex ? styles.dotActive : ''}`}
            onClick={() => setCurrentIndex(i)}
            aria-label={`Go to card ${i + 1}`}
          />
        ))}
      </div>
    </div>
  );
}
