import { useState } from 'react';
import styles from './Navbar.module.css';

export default function Navbar({ activeSection, onSectionChange }) {
  const [menuOpen, setMenuOpen] = useState(false);

  const navItems = [
    { id: 'alphabet', label: 'Alphabet', icon: 'ا' },
    { id: 'vocab', label: 'Flashcards', icon: '📚' },
    { id: 'quiz', label: 'Quiz', icon: '✏️' },
  ];

  return (
    <nav className={styles.navbar}>
      <div className={styles.navContainer}>
        <div className={styles.brand}>
          <span className={styles.brandArabic}>عربي</span>
          <span className={styles.brandText}>Arabic Learn</span>
        </div>

        <button
          className={styles.menuToggle}
          onClick={() => setMenuOpen(!menuOpen)}
          aria-label="Toggle menu"
        >
          <span className={menuOpen ? styles.barOpen : styles.bar}></span>
          <span className={menuOpen ? styles.barOpen : styles.bar}></span>
          <span className={menuOpen ? styles.barOpen : styles.bar}></span>
        </button>

        <ul className={`${styles.navList} ${menuOpen ? styles.navListOpen : ''}`}>
          {navItems.map((item) => (
            <li key={item.id}>
              <button
                className={`${styles.navItem} ${activeSection === item.id ? styles.navItemActive : ''}`}
                onClick={() => {
                  onSectionChange(item.id);
                  setMenuOpen(false);
                }}
              >
                <span className={styles.navIcon}>{item.icon}</span>
                <span>{item.label}</span>
              </button>
            </li>
          ))}
        </ul>
      </div>
    </nav>
  );
}
