import { useState } from 'react';
import Navbar from './components/Navbar';
import AlphabetSection from './components/AlphabetSection';
import VocabSection from './components/VocabSection';
import QuizSection from './components/QuizSection';
import styles from './App.module.css';

export default function App() {
  const [activeSection, setActiveSection] = useState('alphabet');

  const renderSection = () => {
    switch (activeSection) {
      case 'alphabet': return <AlphabetSection />;
      case 'vocab': return <VocabSection />;
      case 'quiz': return <QuizSection />;
      default: return <AlphabetSection />;
    }
  };

  return (
    <div className={styles.app}>
      <Navbar activeSection={activeSection} onSectionChange={setActiveSection} />
      <main className={styles.main}>
        {renderSection()}
      </main>
    </div>
  );
}
