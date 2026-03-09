const usedDates = new Set(logs.map(l => l.UsedDate));
document.getElementById('wornCount').textContent = `Worn ${logs.length} times total`;

if (logs.length > 0) {
    const lastDate = new Date(logs[logs.length -1].UsedDate);
    const daysAgo = Math.floor((new Date() - lastDate) / (1000 * 60 * 60 * 24));
    document.getElementById('lastUsed').textContent = `Last used on ${logs[logs.length - 1].UsedDate}/ ${daysAgo} days ago`;
} else {
    document.getElementById('lastUsed').textContent = 'Never used';
}

let currentYear = new Date().getFullYear();

function renderHeatmap(year) {
    document.getElementById('yearLabel').textContent = year;
    const container = document.getElementById('heatmap');
    container.innerHTML = '';

    const grid = document.createElement('div');
    grid.style.cssText = 'display:flex; flex-direction:row; gap:6px; width:100%;';

    const today = new Date();

    for (let month = 0; month < 12; month++) {
        const monthDiv = document.createElement('div');
        monthDiv.style.cssText = 'display:flex; flex-direction:column; gap:3px; flex:1;';

        const label = document.createElement('div');
        label.textContent = new Date(year, month, 1).toLocaleString('default', { month: 'short' });
        label.style.cssText = 'color:gray; font-size:11px; margin-bottom:4px;';
        monthDiv.appendChild(label);

        const daysDiv = document.createElement('div');
        daysDiv.style.cssText = 'display:flex; flex-wrap:wrap; gap:3px;';

        const daysInMonth = new Date(year, month + 1, 0).getDate();
        for (let day = 1; day <= daysInMonth; day++) {
            const d = new Date(year, month, day);
            const dateStr = `${year}-${String(month + 1).padStart(2, '0')}-${String(day).padStart(2, '0')}`;
            const isFuture = d > today;
            const isWorn = usedDates.has(dateStr);

            const cell = document.createElement('div');
            cell.title = dateStr;
            cell.style.cssText = `
                    width:12px; height:12px; border-radius:2px;
                    background:${isFuture ? 'transparent' : isWorn ? 'orange' : 'whitesmoke'};
                    border:${isFuture ? '1px solid #555' : 'none'};
                    box-sizing:border-box;
                `;
            daysDiv.appendChild(cell);
        }

        monthDiv.appendChild(daysDiv);
        grid.appendChild(monthDiv);
    }

    container.appendChild(grid);
}

function changeYear(delta) {
    currentYear += delta;
    renderHeatmap(currentYear);
}

renderHeatmap(currentYear);
