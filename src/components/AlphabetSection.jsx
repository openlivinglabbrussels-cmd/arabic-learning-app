import { useState } from 'react';
import { alphabet } from '../data/alphabet';
import styles from './AlphabetSection.module.css';

export default function AlphabetSection() {
  const [selected, setSelected] = useState(null);

  return (
    <div className={styles.section}>
      <div className={styles.header}>
        <h1 className={styles.title}>Arabic Alphabet</h1>
        <p className={styles.subtitle}>
          Learn all 28 letters of the Arabic alphabet — click any letter to explore
        </p>
      </div>

      <div className={styles.grid}>
        {alphabet.map((item) => (
          <button
            key={item.id}
            className={`${styles.card} ${selected?.id === item.id ? styles.cardSelected : ''}`}
            onClick={() => setSelected(selected?.id === item.id ? null : item)}
            aria-pressed={selected?.id === item.id}
          >
            <span className={`${styles.letter} arabic`}>{item.letter}</span>
            <span className={styles.name}>{item.name}</span>
            <span className={styles.translit}>{item.transliteration}</span>
          </button>
        ))}
      </div>

      {selected && (
        <div className={styles.detailPanel}>
          <button className={styles.closeBtn} onClick={() => setSelected(null)} aria-label="Close">✕</button>
          <div className={styles.detailContent}>
            <div className={styles.detailLeft}>
              <div className={`${styles.bigLetter} arabic`}>{selected.letter}</div>
              <div className={`${styles.arabicName} arabic`}>{selected.arabicName}</div>
            </div>
            <div className={styles.detailRight}>
              <h2 className={styles.detailName}>{selected.name}</h2>
              <div className={styles.detailRow}>
                <span className={styles.detailLabel}>Pronunciation</span>
                <span className={styles.detailValue}>{selected.transliteration}</span>
              </div>
              <div className={styles.detailRow}>
                <span className={styles.detailLabel}>Example Word</span>
                <span className={`${styles.detailArabic} arabic`}>{selected.example}</span>
              </div>
              <div className={styles.detailRow}>
                <span className={styles.detailLabel}>Meaning</span>
                <span className={styles.detailValue}>{selected.exampleMeaning}</span>
              </div>
              <div className={styles.letterNumber}>
                Letter #{selected.id} of 28
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
