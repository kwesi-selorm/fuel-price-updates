import styles from './checkbox.module.css';

interface Props {
    label: string;
}

export default function Checkbox({ label = 'Label' }: Props) {
    return (
        <div className={styles.wrapper}>
            <input
                id={styles.customCheckbox}
                className={styles.customCheckbox}
                type="checkbox"
            />
            <label
                htmlFor={styles.customCheckbox}
                className={styles.customCheckboxLabel}
            >
                {label}
            </label>
        </div>
    );
}
